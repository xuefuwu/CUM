using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class RoleController : AdminController
    {
        //
        // GET: /Admin/Role/

        public ActionResult Index()
        {
            List<Role> rList = DB.Roles.ToList();
            return View(rList);
        }

        //
        // GET: /Admin/Role/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Role/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Role/Create

        [HttpPost]
        public ActionResult Create(Role r)
        {
            if (ModelState.IsValid)
            {
                DB.Roles.Add(r);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        //
        // GET: /Admin/Role/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.Roles.Find(id));
        }

        //
        // POST: /Admin/Role/Edit/5

        [HttpPost]
        public ActionResult Edit(Role r)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(r).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);

        }

        //
        // GET: /Admin/Role/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Roles.Remove(DB.Roles.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Role/Delete/5

        [HttpPost]
        public ActionResult Delete(Role r)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Role/Assign/5

        public ActionResult Assign(int id)
        {
            ViewData["ActionList"] = DB.ControllerActions.ToList();
            ViewData["ControllRole"] = DB.ControllerActionRoles.Where(r => r.Role.ID == id);
            return View(DB.Roles.Find(id));
        }

        //
        // POST: /Admin/Role/Assign/5

        [HttpPost]
        public ActionResult Assign(String RoleID, FormCollection form)
        {
            var car = new List<ControllerActionRole>();
            Role role = DB.Roles.Find(Convert.ToInt32(RoleID));
            var oldcar = DB.ControllerActionRoles.Where(ca => ca.Role.ID.Equals(role.ID)).ToList();
            oldcar.ForEach(c => DB.ControllerActionRoles.Remove(c));
            String IsAllowed = Request.Form["IsAllowed"];
            String ViewNames = Request.Form["ViewName"];
            String[] res = IsAllowed.Split(',');
            String[] view_res = ViewNames.Split(',');
            int index=0;
            foreach (String id in res)
            {
                String[] id_value = id.Split('_');
                var action = DB.ControllerActions.Find(Convert.ToInt32(id_value[0]));

                car.Add(new ControllerActionRole()
                {
                    ControllerAction = action,
                    Role = role,
                    IsAllowed = Convert.ToBoolean(id_value[1]),
                    ViewName = view_res[index]
                });
                index++;
            }
            car.ForEach(c => DB.ControllerActionRoles.Add(c));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
