using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace BBP.Controllers
{
    public class ExaminationController : BaseController
    {
        //
        // GET: /Examination/

        public ActionResult Index()
        {
            return View(DB.Examinations.ToList());
        }

        //
        // GET: /Examination/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Examinations.Find(id));
        }

        //
        // GET: /Examination/Create

        public ActionResult Create(int? ExamId)
        {
            ViewData["ExaminationTask"] = DB.ExaminationTasks.Find(ExamId);
            return View();
        }

        //
        // POST: /Examination/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            String jsonData = collection[0];
            JObject jsonBody = JObject.Parse(jsonData);
            var taskid = jsonBody.GetValue("TaskId");
            var examids = jsonBody.GetValue("Examinees");
            var questions = jsonBody.GetValue("Questions");
            //遍历radio组装QuestionResult
            IList<QuestionResult> qrList = new List<QuestionResult>();
            foreach (var question in questions)
            {
                Question q = DB.Questions.Find(Convert.ToInt32(question["ID"]));
                qrList.Add(new QuestionResult() { Question = q, QuestionAnswer = question["QuestionAnswer"].ToString() });
            }
            //遍历Examinee，套入QuestionResult
            foreach (var exam in examids)
            {
                ExaminationTask et = DB.ExaminationTasks.Find(Convert.ToInt32(taskid));
                Examinee ex = DB.Examinees.Find(Convert.ToInt32(exam));
                Examination examination = new Examination() {Examinee = ex, QuestionResults = qrList,ExaminationTask=et};
                DB.Examinations.Add(examination);
                DB.SaveChanges();
            }
                //DB.Examinations.Add(ex);
               // DB.SaveChanges();
                return RedirectToAction("Index");

        }

        //
        // GET: /Examination/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.Examinations.Find(id));
        }

        //
        // POST: /Examination/Edit/5

        [HttpPost]
        public ActionResult Edit(Examination ex)
        {
            if (ModelState.IsValid)
            {
                DB.Entry<Examination>(ex).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ex);

        }

        //
        // GET: /Examination/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Examinations.Remove(DB.Examinations.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Examination/Delete/5

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
