using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BBP.Util;

namespace BBP.Controllers
{
    public class SearchController : BaseController
    {
        //
        // POST: /Search/
        [HttpPost]
        public ActionResult Index(String q)
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);

            List<Order> orderList;
            DateTime search_date;
            Boolean parseDatetimeOk = DateTime.TryParse(q, out search_date);
            if (parseDatetimeOk)
            {
                orderList = DB.Orders.Where(o => (o.OrderNo.Contains(q) || o.MachineSN.Contains(q) || o.SN.Contains(q) || o.Customer.Name.Contains(q) || o.Customer.TeleNum.Contains(q) || o.Customer.Email.Contains(q) || DateTime.Compare(o.Created, search_date) == 0 || o.Creator.ChineseName.Contains(q))&&o.Dept.ID.Equals(currentRootDept.ID)).ToList();
            }
            else
            {
                orderList = DB.Orders.Where(o => (o.OrderNo.Contains(q) || o.MachineSN.Contains(q) || o.SN.Contains(q) || o.Customer.Name.Contains(q) || o.Customer.TeleNum.Contains(q) || o.Customer.Email.Contains(q) || o.Creator.ChineseName.Contains(q)) && o.Dept.ID.Equals(currentRootDept.ID)).ToList();
            }
        return View(orderList);
        }

        //GET:/Search/Adv

        public ActionResult AdvSearch()
        {
            return View();
        }
        
        //POST: /Search/Adv
        [HttpPost]
        public ActionResult AdvSearch(String StartDateStr,String EndDateStr)
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);

            DateTime StartDate,EndDate;
            List<Order> orderList;
            Boolean parseStartOk = DateTime.TryParse(StartDateStr, out StartDate),parseEndOk = DateTime.TryParse(EndDateStr,out EndDate);
            if (parseStartOk && parseEndOk)
            {
                ViewData["StartDate"] = StartDateStr;
                ViewData["EndDate"] = EndDateStr;
                orderList = DB.Orders.Where(o => DateTime.Compare(o.Created, StartDate) >= 0 && DateTime.Compare(o.Created, EndDate) <= 0 && o.Dept.ID.Equals(currentRootDept.ID)).ToList();
                if (orderList != null)
                {
                    return View(orderList);
                }
                else
                {
                    return RedirectToAction("AdvSearch", new { ErrorMessage = "没有搜索到数据" });
                }
            }
            else
            {
                return RedirectToAction("AdvSearch", new { ErrorMessage = "日期格式错误" });
            }
        }

        
        public ActionResult Export(String StartDateStr, String EndDateStr)
        {
            byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);

            DateTime StartDate, EndDate;
            List<Order> orderList;
            Boolean parseStartOk = DateTime.TryParse(StartDateStr, out StartDate), parseEndOk = DateTime.TryParse(EndDateStr, out EndDate);
            if (parseStartOk && parseEndOk)
            {
                ViewData["StartDate"] = StartDateStr;
                ViewData["EndDate"] = EndDateStr;
                orderList = DB.Orders.Where(o => DateTime.Compare(o.Created, StartDate) >= 0 && DateTime.Compare(o.Created, EndDate) <= 0 && o.Dept.ID.Equals(currentRootDept.ID)).ToList();
                if (orderList != null)
                {
                    StringBuilder strColu = new StringBuilder();

                    strColu.Append("\"日期\"");
                    strColu.Append(",");
                    strColu.Append("\"单号\"");
                    strColu.Append(",");
                    strColu.Append("\"流水号\"");
                    strColu.Append(",");
                    strColu.Append("\"序列号\"");
                    strColu.Append(",");
                    strColu.Append("\"机器型号\"");
                    strColu.Append(",");
                    strColu.Append("\"客户姓名\"");
                    strColu.Append(",");
                    strColu.Append("\"联系电话\"");
                    strColu.Append(",");
                    strColu.Append("\"邮箱\"");
                    strColu.Append(",");
                    strColu.Append("\"机位\"");
                    strColu.Append(",");
                    strColu.Append("\"维保状态\"");
                    strColu.Append(",");
                    strColu.Append("\"维修状态\"");
                    strColu.Append(",");
                    strColu.Append("\"结单\"");
                    strColu.Append(",");
                    strColu.AppendLine("\"取件\"");
                    orderList.ForEach(o => strColu.Append("\""+o.Created + "\",")
                        .Append("\"" + o.OrderNo + "\",")
                        .Append("\"" + o.SN + "\",")
                        .Append("\"" + o.MachineSN + "\",")
                        .Append("\"" + o.MachineModel + "\",")
                        .Append("\"" + o.Customer.Name + "\",")
                        .Append("\"" + o.Customer.TeleNum + "\",")
                        .Append("\"" + o.Customer.Email + "\",")
                        .Append("\"" + o.Position + "\",")
                        .Append("\"" + o.Guarantee + "\",")
                        .Append("\"" + o.Status + "\",")
                        .Append("\"" + o.Paid + "\",")
                        .AppendLine("\"" + o.Receive + "\""));
                    byte[] buff = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(strColu.ToString()));
                    byte[] output = new byte[bomBuffer.Length + buff.Length];
                    Response.Clear();
                    Response.Charset = "UTF-8";
                    Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                    Response.ContentType = "application/CSV";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("export.csv"));
                    Response.Write(strColu.ToString());
                    Response.End();
                    return new EmptyResult();
                   // return View(orderList);
                }
                else
                {
                    return RedirectToAction("AdvSearch", new { ErrorMessage = "没有搜索到数据" });
                }
            }
            else
            {
                return RedirectToAction("AdvSearch", new { ErrorMessage = "日期格式错误" });
            }
        }
    }
}
