using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class ActionsController : AdminController
    {
        //
        // GET: /Admin/Actions/

        public ActionResult Index()
        {
            return View(DB.ControllerActions.ToList());
        }

        //
        // GET: /Admin/Actions/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Actions/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Actions/Create

        [HttpPost]
        public ActionResult Create(ControllerAction c)
        {
            if (ModelState.IsValid)
            {
                DB.ControllerActions.Add(c);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);

        }

        //
        // GET: /Admin/Actions/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.ControllerActions.Find(id));
        }

        //
        // POST: /Admin/Actions/Edit/5

        [HttpPost]
        public ActionResult Edit(ControllerAction c)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);

        }

        //
        // GET: /Admin/Actions/Delete/5

        public ActionResult Delete(int id)
        {
            DB.ControllerActions.Remove(DB.ControllerActions.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Actions/Delete/5

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
