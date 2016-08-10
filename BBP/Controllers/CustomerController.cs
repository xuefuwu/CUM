using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Util;

namespace BBP.Controllers
{
    public class CustomerController : BaseController
    {
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            List<Customer> cList = DB.Customers.Where(o => o.Creator!=null).ToList();
            for (int i = 0; i < cList.Count; i++)
            {
                if (DeptHelper.getRootDept(cList[i].Creator.Dept.ID, DB).ID.Equals(currentRootDept.ID))
                {
                    cList.RemoveAt(i);
                }
            }
            ViewData["ObjList"] = cList;
            return View();
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                User currentUser = Session["CurrentUser"] as User;
                c.Creator = currentUser;
                DB.Customers.Add(c);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Customer c = DB.Customers.Find(id);
            return View(c);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer c)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(c).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Customer c = DB.Customers.Find(id);
            if (c.Orders.Count == 0)
            {
                DB.Customers.Remove(c);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { ErrorMessage = "客户已下单无法删除" });
            }
           
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(Customer c)
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
