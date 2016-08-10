using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Controllers
{
    public class ExaminationTaskController : BaseController
    {
        //
        // GET: /ExaminationTask/

        public ActionResult Index()
        {
            return View(DB.ExaminationTasks.ToList());
        }

        //
        // GET: /ExaminationTask/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.ExaminationTasks.Find(id));
        }

        //
        // GET: /ExaminationTask/Create

        public ActionResult Create()
        {
            ViewData["Examinees"] = DB.Examinees.ToList();
            ViewData["Questions"] = DB.Questions.ToList();
            return View();
        }

        //
        // POST: /ExaminationTask/Create

        [HttpPost]
        public ActionResult Create(ExaminationTask et, string[] ExamineeIds, string[] Question, string[] QuestionScore)
        {
            if (ModelState.IsValid)
            {
                et.Created = DateTime.Now;

                IList<Examinee> exList = new List<Examinee>();
                IList<ExamQuestion> qList = new List<ExamQuestion>();
                foreach (string eid in ExamineeIds)
                {
                    exList.Add(DB.Examinees.Find(Convert.ToInt32(eid)));
                }
                et.Examinees = exList;
                for (int i = 0; i < Question.Length; i++)
                {
                    qList.Add(DB.ExamQuestions.Add(new ExamQuestion()
                    {
                        Question = DB.Questions.Find(Convert.ToInt32(Question[i])),
                        Score = Convert.ToDouble(QuestionScore[i])
                    }));
                }
                et.Questions = qList;
                DB.ExaminationTasks.Add(et);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /ExaminationTask/Edit/5

        public ActionResult Edit(int id)
        {
            ExaminationTask et = DB.ExaminationTasks.Find(id);
            ICollection<Examinee> existExaminee = et.Examinees;
            ICollection<Examinee> allExaminee = DB.Examinees.ToList();
            IList<Examinee> notExistExaminees = new List<Examinee>();

            ICollection<ExamQuestion> existQuestion = et.Questions;
            ICollection<Question> allQuestion = DB.Questions.ToList();
            IList<Question> notExistQuestions = new List<Question>();

            allQuestion.Where(qu1 => existQuestion.Count(etq1 => etq1.Question.ID == qu1.ID) == 0)
                .ToList()
                .ForEach(req => notExistQuestions.Add(req));
            allExaminee.Where(ex1 => existExaminee.Count(etx1 => etx1.ID == ex1.ID) == 0)
                .ToList()
                .ForEach(rex => notExistExaminees.Add(rex));
            ViewData["Examinees"] = notExistExaminees;
            ViewData["Questions"] = notExistQuestions;
            return View(et);
        }

        //
        // POST: /ExaminationTask/Edit/5

        [HttpPost]
        public ActionResult Edit(ExaminationTask et, string[] ExamineeIds, string[] Question, string[] QuestionScore)
        {
            if (ModelState.IsValid)
            {
                et = DB.ExaminationTasks.Find(et.ID);
                et.Questions.Clear();
                et.Examinees.Clear();
                IList<Examinee> exList = new List<Examinee>();
                IList<ExamQuestion> qList = new List<ExamQuestion>();

                foreach (string eid in ExamineeIds)
                {
                    exList.Add(DB.Examinees.Find(Convert.ToInt32(eid)));
                }
                et.Examinees = exList;
                for (int i = 0; i < Question.Length; i++)
                {
                    qList.Add(DB.ExamQuestions.Add(new ExamQuestion()
                    {
                        Question = DB.Questions.Find(Convert.ToInt32(Question[i])),
                        Score = Convert.ToDouble(QuestionScore[i])
                    }));
                }
                et.Questions = qList;
                DB.Entry(et).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(et);
        }

        //
        // GET: /ExaminationTask/Delete/5

        public ActionResult Delete(int id)
        {
            DB.ExaminationTasks.Remove(DB.ExaminationTasks.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /ExaminationTask/Delete/5

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
