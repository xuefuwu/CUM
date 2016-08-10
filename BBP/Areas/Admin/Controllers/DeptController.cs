using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class DeptController : AdminController
    {
        //
        // GET: /Admin/Dept/

        public ActionResult Index()
        {
            return View(DB.Depts.OrderBy(d => d.Parent.ID).ToList());
        }

        //
        // GET: /Admin/Dept/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Dept/Create

        public ActionResult Create()
        {
            ViewData["deptList"] = DB.Depts.ToList();
            return View();
        }

        //
        // POST: /Admin/Dept/Create

        [HttpPost]
        public ActionResult Create(Dept d)
        {
            d.Parent = DB.Depts.Find(d.Parent.ID);
            //if (ModelState.IsValid)
            //{
                DB.Depts.Add(d);
                DB.SaveChanges();
                return RedirectToAction("Index");
            ///}

           // return View(d);

        }

        //
        // GET: /Admin/Dept/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData["deptList"] = DB.Depts.Where(d => d.ID != id);
            return View(DB.Depts.Find(id));
        }

        //
        // POST: /Admin/Dept/Edit/5

        [HttpPost]
        public ActionResult Edit(Dept d, Dept Parent)
        {
            d.Parent = DB.Depts.Find(Parent.ID);
            //if (ModelState.IsValid)
            //{
                DB.Entry(d).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
           // }

           //
            //return View(d);

        }

        //
        // GET: /Admin/Dept/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Depts.Remove(DB.Depts.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Dept/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
