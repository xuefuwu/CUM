using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Areas.Admin.Controllers
{
    public class EtAttrController : AdminController
    {
        //
        // GET: /Admin/ETAttr/

        public ActionResult Index()
        {
            return View(DB.ETAttrs.ToList());
        }


        //
        // GET /Admin/ETAttr/Index?ext=1
        public ActionResult Index(int ext)
        {
            ExamineeType et = DB.ExamineeTypes.Find(ext);
            return View(DB.ETAttrs.Where(eta => eta.ValueType.ID == et.ID).ToList());
        }
        //
        // GET: /Admin/ETAttr/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.ETAttrs.Find(id));
        }

        //
        // GET: /Admin/ETAttr/Create

        public ActionResult Create(int etid)
        {
            ViewData["ExamType"] = DB.ExamineeTypes.Find(etid);
            return View();
        }

        //
        // POST: /Admin/ETAttr/Create

        [HttpPost]
        public ActionResult Create(ETAttr eta,int vtid,int etid)
        {
            if (ModelState.IsValid)
            {
                eta.ValueType = DB.ValueTypes.Find(etid);
                ExamineeType et = DB.ExamineeTypes.Find(etid);
                DB.ETAttrs.Add(eta);
                et.ExtAttrs.Add(eta);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        //
        // GET: /Admin/ETAttr/Edit/5

        public ActionResult Edit(int id,int etid)
        {
            ViewData["ExamType"] = DB.ExamineeTypes.Find(etid);
            return View(DB.ETAttrs.Find(id));
        }

        //
        // POST: /Admin/ETAttr/Edit/5

        [HttpPost]
        public ActionResult Edit(ETAttr eta,int etid)
        {
            if(ModelState.IsValid)
            {
                DB.Entry(eta).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();
            
        }

        //
        // GET: /Admin/ETAttr/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ETAttr/Delete/5

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
