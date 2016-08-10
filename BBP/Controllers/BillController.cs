using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Util;

namespace BBP.Controllers
{
    public class BillController : BaseController
    {
        //
        // GET: /Bill/

        public ActionResult Index()
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            List<OrderBill> list = DB.Bills.ToList();
            return View(list);
        }

        public IList<OrderBill> GetAllOUsByParent(int parentID)
        {
            Dept rootDept = DB.Depts.Find(parentID);
            List<OrderBill> list = DB.Bills.Where(s => s.person.Dept.ID == rootDept.ID || rootDept.Children.Contains(s.person.Dept)).ToList();
            foreach (OrderBill info in list)
            {
                list.AddRange(GetAllOUsByParent(info.person.Dept.ID));
            }
            return list;
        }
        //
        // GET: /Bill/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Bills.Find(id));
        }

        //
        // GET: /Bill/Create

        public ActionResult Create()
        {
            ViewData["Users"] = DB.Users.ToList();
            return View();
        }

        //
        // POST: /Bill/Create

        [HttpPost]
        public ActionResult Create(OrderBill b)
        {
            b.Order = DB.Orders.Where(o => o.OrderNo == b.Order.OrderNo).FirstOrDefault<Order>();
            b.person = DB.Users.Where(u => u.ID == b.person.ID).FirstOrDefault<User>();
            //if (ModelState.IsValid)
            //{
            DB.Bills.Add(b);
            DB.SaveChanges();
            return RedirectToAction("Index");
            //}

            // return View(b);

        }

        //
        // GET: /Bill/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData["Users"] = DB.Users.ToList();

            return View(DB.Bills.Find(id));
        }

        //
        // POST: /Bill/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderBill b)
        {
            b.Order = DB.Orders.Where(o => o.OrderNo == b.Order.OrderNo).FirstOrDefault<Order>();
            b.person = DB.Users.Where(u => u.ID == b.person.ID).FirstOrDefault<User>();

            //if (ModelState.IsValid)
            //{
                DB.Entry(b).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            //}

           // return View(b);

        }

        //
        // GET: /Bill/Delete/5

        public ActionResult Delete(int id)
        {
            DB.Bills.Remove(DB.Bills.Find(id));
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Bill/Delete/5

        [HttpPost]
        public ActionResult Delete(OrderBill b)
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


        //
        // GET: /Bill/Add

        public ActionResult Add(int id, String returnAction)
        {
            ViewData["returnAction"] = returnAction;
            ViewData["Users"] = DB.Users.AsEnumerable();

            return View(DB.Orders.Find(id));
        }

        //
        // POST: /Bill/Add

        [HttpPost]
        public ActionResult Add(OrderBill b, String returnAction)
        {
            b.Order = DB.Orders.Where(o => o.OrderNo == b.Order.OrderNo).FirstOrDefault<Order>();
            b.person = DB.Users.Where(u => u.ID == b.person.ID).FirstOrDefault<User>();
            //if (ModelState.IsValid)
            //{
            DB.Bills.Add(b);
            DB.SaveChanges();
            return RedirectToAction(returnAction, "Order", new { id = b.Order.ID });
            //}

            // return View(b);

        }

    }
}
