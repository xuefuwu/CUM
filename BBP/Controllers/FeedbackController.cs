using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBP.Controllers
{
    public class FeedbackController : BaseController
    {
        //
        // GET: /Feedback/

        public ActionResult Index()
        {
            return View(DB.Feedbacks.ToList());
        }

        //
        // GET: /Feedback/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Feedbacks.Find(id));
        }

        //
        // GET: /Feedback/Create

        public ActionResult Create(int? ExamId)
        {
            ViewData["Examination"] = DB.Examinations.Find(ExamId);
            return View();
        } 

        //
        // POST: /Feedback/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Feedback/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Feedback/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Feedback/Delete/5
 
        public ActionResult Delete(int id)
        {
            DB.Feedbacks.Remove(DB.Feedbacks.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Feedback/Delete/5

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
        public JsonResult UploadImg()
        {
            JsonResult res = new JsonResult();
            String imgurl = "";
            if (Request.Form.AllKeys.Any(m => m == "chunk"))
            {
                //取得chunk和chunks
                int chunk = Convert.ToInt32(Request.Form["chunk"]);
                int chunks = Convert.ToInt32(Request.Form["chunks"]);


                //根据GUID创建用该GUID命名的临时文件
                string path = Server.MapPath("~/Uploads/" + Request["guid"]);
                FileStream addFile = new FileStream(path, FileMode.Append, FileAccess.Write);
                BinaryWriter AddWriter = new BinaryWriter(addFile);
                //获得上传的分片数据流
                HttpPostedFileBase file = Request.Files[0];
                Stream stream = file.InputStream;

                BinaryReader TempReader = new BinaryReader(stream);
                //将上传的分片追加到临时文件末尾
                AddWriter.Write(TempReader.ReadBytes((int)stream.Length));
                //关闭BinaryReader文件阅读器
                TempReader.Close();
                stream.Close();
                AddWriter.Close();
                addFile.Close();

                TempReader.Dispose();
                stream.Dispose();
                AddWriter.Dispose();
                addFile.Dispose();
                //如果是最后一个分片，则重命名临时文件为上传的文件名
                if (chunk == (chunks - 1))
                {
                    FileInfo fileinfo = new FileInfo(path);
                    imgurl = @"~/Uploads/" + Request.Files[0].FileName;
                    fileinfo.MoveTo(Server.MapPath(imgurl));
                }
            }
            else//没有分片直接保存
            {
                imgurl = @"~/Uploads/" + Request.Files[0].FileName;
                Request.Files[0].SaveAs(Server.MapPath(imgurl));
            }
            res.Data = res.Data = "{\"url\":\"" + imgurl + "\"}";
            return res;
        }
    }
}
