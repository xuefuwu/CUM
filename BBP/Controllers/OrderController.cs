using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using BBP.Models;
using BBP.Util;

namespace BBP.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            Type type = Type.GetType("BBP.Order");
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            List<Order> currentlist = new List<Order>();
            Expression right = null;

            if (currentUser.Roles.Count > 0)
            {
                currentlist = DB.Orders.Where(o => o.Dept.ID.Equals(currentRootDept.ID)).Where(currentUser).ToList();
                return View(currentlist);
            }
            else
            {
                throw new Exception("Error Roles!");
            }
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View(DB.Orders.Find(id));
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            StoreUtil store = new StoreUtil();
            List<String> instore = DB.Orders.Where(o => (o.Receive == "未取件" || o.Receive == "" || o.Receive == null)&&o.Dept.ID.Equals(currentRootDept.ID)).Select(o => o.Position).ToList();
            ViewData["Store"] = store.getEmptyStack(instore);

            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(Order order, OrderBill OrderBill)
        {
            try
            {
                order.Creator = DB.Users.Find(order.Creator.ID);
                User currentUser = order.Creator;
                Customer customer = DB.Customers.Where(c => c.Name.Equals(order.Customer.Name) && c.TeleNum.Equals(order.Customer.TeleNum)).FirstOrDefault();
                if (customer != null)
                {
                    order.Customer = customer;
                }
                order.Dept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
                order.Status = "待检";
                if (OrderBill.Type != null && !OrderBill.Amount.Equals(0.0))
                {
                    order.Bills = new List<OrderBill>() { new OrderBill() { Type = OrderBill.Type, Amount = OrderBill.Amount, Created = order.Created, person = order.Creator } };
                }
                else
                {
                    order.Bills = new List<OrderBill>();
                }
                DB.Orders.Add(order);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return View();
            }

            //return View(order);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            User currentUser = Session["CurrentUser"] as User;
            Dept currentRootDept = DeptHelper.getRootDept(currentUser.Dept.ID, DB);
            //if (currentUser.Powers.Where(p => p.ID == 1 || p.ID == 2).Count() > 0)
                ViewData["Users"] = DB.Users.Where(currentUser).ToList();

            StoreUtil store = new StoreUtil();
            List<String> instore = DB.Orders.Where(o => (o.Receive == "未取件" || o.Receive == "" || o.Receive == null) && o.Dept.ID.Equals(currentRootDept.ID)).Select(o => o.Position).ToList();
            ViewData["Store"] = store.getEmptyStack(instore);

            Order order = DB.Orders.Find(id);
            String viewName = "Edit";
            if (currentUser.Roles.Count > 0)
            {
                String controllerName = this.ControllerContext.RouteData.Values["controller"] as String;
                String actionName = this.ControllerContext.RouteData.Values["action"] as String;
                Role role = currentUser.Roles.FirstOrDefault();
                ControllerActionRole car = DB.ControllerActionRoles.Where(ca => ca.Role.ID.Equals(role.ID) && ca.ControllerAction.Name == actionName && ca.ControllerAction.ControllName == controllerName).FirstOrDefault();
                if (car != null)
                {
                    viewName = car.ViewName;
                }
            }
            return View(viewName, order);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        [OrderControllerExt]
        public ActionResult Edit(Order order, RepairDetail RepairDetail)
        {

            //if (ModelState.IsValid)
            //{
            DB.Entry(order).State = EntityState.Modified;
            if (RepairDetail.RepairContent != null)
            {
                User currentUser;
                if (RepairDetail.Engineer.ID != 0)
                {
                    currentUser = DB.Users.Find(RepairDetail.Engineer.ID);
                }
                else
                {
                    currentUser = Session["CurrentUser"] as User;
                }

                RepairDetail.Order = order;
                RepairDetail.Engineer = currentUser;
                DB.RepairDetails.Add(RepairDetail);
            }
            DB.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(order);
        }

        //
        // GET: /Order/Delete/5
        //可以试用拦截器写一个规则
        public ActionResult Delete(int id)
        {
            User currentUser = DB.Users.Find((Session["CurrentUser"] as User).ID);
            Order order = DB.Orders.Find(id);
            if (order.Creator.ID.Equals(currentUser.ID))
            {
                DB.Orders.Remove(order);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { ErrorMessage = "无法删除别人创建的记录" });
            }
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(Order o)
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
