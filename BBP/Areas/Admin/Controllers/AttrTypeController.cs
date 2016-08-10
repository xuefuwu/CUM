using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;

namespace BBP.Areas.Admin.Controllers
{
    public class AttrTypeController : AdminController
    {
        //
        // GET: /Admin/AttrType/

        public ActionResult Index()
        {
            return View(DB.AttrTypes.ToList());
        }

        //
        // GET: /Admin/AttrType/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.AttrTypes.Find(id));
        }

        //
        // GET: /Admin/AttrType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/AttrType/Create

        [HttpPost]
        public ActionResult Create(AttrType c)
        {
            if (ModelState.IsValid)
            {
                DB.AttrTypes.Add(c);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        
        //
        // GET: /Admin/AttrType/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(DB.AttrTypes.Find(id));
        }

        //
        // POST: /Admin/AttrType/Edit/5

        [HttpPost]
        public ActionResult Edit(AttrType c)
        {
            if(ModelState.IsValid){
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(c);
            
        }

        //
        // GET: /Admin/AttrType/Delete/5
 
        public ActionResult Delete(int id)
        {
            DB.AttrTypes.Remove(DB.AttrTypes.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/AttrType/Delete/5

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
