using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Areas.Admin.Controllers
{
    /// <summary>
    /// 考核对象
    /// </summary>
    public class ExamineeController : AdminController
    {
        //
        // GET: /Admin/Examinee/

        public ActionResult Index()
        {
            return View(DB.Examinees.ToList());
        }

        //
        // GET: /Admin/Examinee/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Examinees.Find(id));
        }

        //
        // GET: /Admin/Examinee/Create

        public ActionResult Create(int? typeId)
        {
            ViewData["ExamineeTypeList"] = DB.ExamineeTypes.ToList();
            String viewName = "CreateEmptyType";
            if (typeId.HasValue)
            {
                viewName = "Create";
                ViewData["ExamineeType"] = DB.ExamineeTypes.Find(typeId.Value);
            }
            return View(viewName);
        }

        //
        // POST: /Admin/Examinee/Create

        [HttpPost]
        public ActionResult Create(ExamineeType ExamineeType, FormCollection collection)
        {
            Examinee ex = new Examinee();
            if (ModelState.IsValid)
            {
                ExamineeType = DB.ExamineeTypes.Find(ExamineeType.ID);
                ex.ExamineeType = ExamineeType;
                ICollection<AttrValue> ExtAttrs = new List<AttrValue>();
                foreach (var eta in ExamineeType.ExtAttrs)
                {
                    AttrValue av = new AttrValue() { EtAttr = eta, ExtAttrValue = collection[eta.AttrName] };
                    ExtAttrs.Add(av);
                }
                ex.ExtAttrs = ExtAttrs;
                DB.Examinees.Add(ex);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ex);
        }

        //
        // GET: /Admin/Examinee/Edit/5

        public ActionResult Edit(int id, int? typeId)
        {
            Examinee ex = DB.Examinees.Find(id);
            ViewData["ExamineeTypeList"] = DB.ExamineeTypes.ToList();
            if (typeId.HasValue)
            {
                ViewData["ExamineeType"] = DB.ExamineeTypes.Find(typeId.Value);
            }
            else
            {
                ViewData["ExamineeType"] = ex.ExamineeType;
            }
            return View(ex);
        }

        //
        // POST: /Admin/Examinee/Edit/5

        [HttpPost]
        public ActionResult Edit(Examinee ex, ExamineeType ExamineeType, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var existav = from at in DB.ExamineeAttrValue
                            where at.Examinee.ID == ex.ID
                            select at;
                foreach (var attr in existav)
                {
                    DB.ExamineeAttrValue.Remove(DB.ExamineeAttrValue.Find(attr.ID));
                }
                ex = DB.Examinees.Find(ex.ID);
                ExamineeType = DB.ExamineeTypes.Find(ExamineeType.ID);
                ex.ExamineeType = ExamineeType;
                ICollection<AttrValue> ExtAttrs = new List<AttrValue>();
                foreach (var eta in ExamineeType.ExtAttrs)
                {
                    AttrValue av = new AttrValue() { EtAttr = eta, ExtAttrValue = collection[eta.AttrName] };
                    ExtAttrs.Add(av);
                }
                ex.ExtAttrs = ExtAttrs;
                DB.Entry<Examinee>(ex).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ex);
        }

        //
        // GET: /Admin/Examinee/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Examinees.Remove(DB.Examinees.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Examinee/Delete/5

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
