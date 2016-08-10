using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class TitleController : AdminController
    {
        //
        // GET: /Admin/Title/

        public ActionResult Index()
        {
            return View(DB.Titles.ToList());
        }

        //
        // GET: /Admin/Title/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Title/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Title/Create

        [HttpPost]
        public ActionResult Create(Title t)
        {
            if (ModelState.IsValid)
            {
                DB.Titles.Add(t);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t);

        }

        //
        // GET: /Admin/Title/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.Titles.Find(id));
        }

        //
        // POST: /Admin/Title/Edit/5

        [HttpPost]
        public ActionResult Edit(Title t)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(t).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t);

        }

        //
        // GET: /Admin/Title/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Titles.Remove(DB.Titles.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Title/Delete/5

        [HttpPost]
        public ActionResult Delete(Title t)
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
