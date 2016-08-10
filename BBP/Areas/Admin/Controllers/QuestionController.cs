using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Areas.Admin.Controllers
{
    public class QuestionController : AdminController
    {
        //
        // GET: /Admin/Question/

        public ActionResult Index()
        {
            return View(DB.Questions.ToList());
        }

        //
        // GET: /Admin/Question/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Questions.Find(id));
        }

        //
        // GET: /Admin/Question/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Question/Create

        [HttpPost]
        public ActionResult Create(Question q)
        {
            if(ModelState.IsValid)
            {
                DB.Questions.Add(q);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(q);
        }
        
        //
        // GET: /Admin/Question/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(DB.Questions.Find(id));
        }

        //
        // POST: /Admin/Question/Edit/5

        [HttpPost]
        public ActionResult Edit(Question q)
        {
            if (ModelState.IsValid)
            {
                DB.Entry<Question>(q).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(q);
        }

        //
        // GET: /Admin/Question/Delete/5
 
        public ActionResult Delete(int id)
        {
            DB.Questions.Remove(DB.Questions.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/Question/Delete/5

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
