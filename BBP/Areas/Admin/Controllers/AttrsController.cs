using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Areas.Admin.Controllers
{
    public class AttrsController : AdminController
    {
        //
        // GET: /Admin/Attrs/

        public ActionResult Index()
        {
            return View(DB.Attrs.ToList());
        }

        //
        // GET: /Admin/Attrs/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Attrs.Find(id));
        }

        //
        // GET: /Admin/Attrs/Create

        public ActionResult Create()
        {
            ViewData["AttrTypes"] = DB.AttrTypes.ToList();
            ViewData["ValueType"] = DB.ValueTypes.ToList();
            return View();
        } 

        //
        // POST: /Admin/Attrs/Create

        [HttpPost]
        public ActionResult Create(Attrs a, String AttrType, String ValueType)
        {
            int At_id = Convert.ToInt32(AttrType);
            a.AttrType = DB.AttrTypes.Where(at => at.ID == At_id).FirstOrDefault<AttrType>();
            int vt_id= Convert.ToInt32(ValueType);
            a.ValueType = DB.ValueTypes.Where(vt => vt.ID == vt_id).FirstOrDefault<ValueType>();
            DB.Attrs.Add(a);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Admin/Attrs/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewData["AttrTypes"] = DB.AttrTypes.ToList();
            return View();
        }

        //
        // POST: /Admin/Attrs/Edit/5

        [HttpPost]
        public ActionResult Edit(Attrs a)
        {
            a.AttrType = DB.AttrTypes.Where(at => at.ID == a.AttrType.ID).FirstOrDefault<AttrType>();
            DB.Entry(a).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Attrs/Delete/5
 
        public ActionResult Delete(int id)
        {
            DB.Attrs.Remove(DB.Attrs.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Attrs/Delete/5

        [HttpPost]
        public ActionResult Delete(Attrs a)
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
