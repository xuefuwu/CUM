using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;
using Newtonsoft.Json.Linq;

namespace BBP.Areas.Admin.Controllers
{
    /// <summary>
    /// 考核对象类型
    /// </summary>
    public class ExamineeTypeController : AdminController
    {
        //
        // GET: /Admin/ExamineeType/

        public ActionResult Index()
        {
            return View(DB.ExamineeTypes.ToList());
        }

        //
        // GET: /Admin/ExamineeType/Details/5

        public ActionResult Details(int id)
        {
            ExamineeType e = DB.ExamineeTypes.Find(id);
            ViewData["ExtAttrs"] = DB.ETAttrs.Where(et=>et.ValueType.ID==e.ID).ToList();
            return View(e);
        }

        //
        // GET: /Admin/ExamineeType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ExamineeType/Create

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(JsonModelBinder<ExamineeType>))]ExamineeType examineeType)
        {
            if (ModelState.IsValid)
            {
                //foreach (var ext in examineeType.ExtAttrs)
                //{
                //    ext.ValueType = DB.ValueTypes.Find(ext.ValueType.ID);
                //}
                DB.ExamineeTypes.Add(examineeType);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examineeType);

        }

        //
        // GET: /Admin/ExamineeType/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.ExamineeTypes.Find(id));
        }

        //
        // POST: /Admin/ExamineeType/Edit/5

        [HttpPost]
        public ActionResult Edit([ModelBinder(typeof(JsonModelBinder<ExamineeType>))]ExamineeType examineeType)
        {
            if (ModelState.IsValid)
            {
                var et = DB.ExamineeTypes.Find(examineeType.ID);
                var existAttr = from d in DB.ETAttrs
                    where d.ExamineeType.ID == et.ID
                    select d;
                foreach (var attr in existAttr)
                {
                    DB.ETAttrs.Remove(DB.ETAttrs.Find(attr.ID));
                }
                foreach (var ext in examineeType.ExtAttrs)
                {
                    ext.ValueType = DB.ValueTypes.Find(ext.ValueType.ID);
                    et.ExtAttrs.Add(ext);
                }
                et.TypeName = examineeType.TypeName;
                var entry = DB.Entry<ExamineeType>(et);

                entry.State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examineeType);
        }

        //
        // GET: /Admin/ExamineeType/Delete/5

        public ActionResult Delete(int id)
        {
            DB.ExamineeTypes.Remove(DB.ExamineeTypes.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RowEditing(ETAttr ea, FormCollection f)
        {
            return View();
        }

        [HttpPost]
        public JsonResult RowDelete(int eaid)
        {
            JsonResult res = new JsonResult();
            DB.ETAttrs.Remove(DB.ETAttrs.Find(eaid));
            DB.SaveChanges();
            return res;
        }
        //
        // POST: /Admin/ExamineeType/Delete/5

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

        [HttpPost]
        public JsonResult GetSelectData()
        {
            JsonResult res = new JsonResult();
            String resStr = "{";
            var selectData = DB.ValueTypes.ToList();
            foreach (var d in selectData)
            {
                resStr += "\""+d.ID + "\":\"" + d.ValueTypeName+"\",";
            }
            resStr = resStr.TrimEnd(',');
            resStr += "}";

            res.Data = resStr;
            //res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        [HttpPost]
        public JsonResult GetTableData(int typeId)
        {
            JsonResult res = new JsonResult();
            var tableData = DB.ETAttrs.Where(t => t.ExamineeType.ID == typeId).Select(item => new { item.ID, item.AttrName,item.AttrText,item.AttrValue,item.ValueType }).ToList();
            res.Data = tableData;
            return res;
        }
    }
}
