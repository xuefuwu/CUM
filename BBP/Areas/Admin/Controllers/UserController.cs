using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBP.Controllers;


namespace BBP.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            List<User> userList = DB.Users.ToList();
            ViewData["ObjList"] = userList;
            return View(userList);
        }

        //
        // GET: /Admin/User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/User/Create

        public ActionResult Create()
        {
            ViewData["roleList"] = DB.Roles.ToList();
            ViewData["deptList"] = DB.Depts.ToList();
            ViewData["titleList"] = DB.Titles.ToList();
            ViewData["powerList"] = DB.Powers.ToList();
            return View();
        }

        //
        // POST: /Admin/User/Create

        [HttpPost]
        public ActionResult Create(User u, Dept Dept, Role Role, Title Title,Power Power)
        {
            u.Dept = DB.Depts.Find(Dept.ID);
            u.Titles = new List<Title>() { (DB.Titles.Find(Title.ID)) };
            u.Roles = new List<Role>() { DB.Roles.Find(Role.ID) };
            u.Powers = new List<Power>() { DB.Powers.Find(Power.ID) };
            u.Password = PasswordUtil.CreateDbPassword(u.Password);
            //if (ModelState.IsValid)
            //{
            DB.Users.Add(u);
            DB.SaveChanges();
            return RedirectToAction("Index");
            //}
            //return View(u);
        }

        //
        // GET: /Admin/User/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData["roleList"] = DB.Roles.ToList();
            ViewData["deptList"] = DB.Depts.ToList();
            ViewData["titleList"] = DB.Titles.ToList();
            ViewData["powerList"] = DB.Powers.ToList();

            User user = DB.Users.Find(id);
            return View(user);
        }

        //
        // POST: /Admin/User/Edit/5

        [HttpPost]
        public ActionResult Edit(User User, Role Role, Title Title,Power Power, FormCollection form5)
        {
            User item = DB.Users
            .Include(u => u.Dept)
            .Include(u => u.Roles)
            .Include(u => u.Titles)
            .Where(u => u.ID == User.ID).FirstOrDefault();
            item.ChineseName = User.ChineseName;
            item.Gender = User.Gender;
            item.Email = User.Email;
            item.OfficePhone = User.OfficePhone;
            item.Remark = User.Remark;
            item.Enabled = User.Enabled;
            if (null != User.Password)
            {
                item.Password = PasswordUtil.CreateDbPassword(User.Password);
            }
            Dept dept = DB.Depts.Attach(DB.Depts.Where(x => x.ID == User.Dept.ID).FirstOrDefault());
            item.Dept = dept;

            item.Roles.Clear();
            item.Titles.Clear();

            Title title = DB.Titles.Attach(DB.Titles.Where(x => x.ID == Title.ID).FirstOrDefault());
            Role role = DB.Roles.Attach(DB.Roles.Where(x => x.ID == Role.ID).FirstOrDefault());
            Power power = DB.Powers.Attach(DB.Powers.Where(x => x.ID == Power.ID).FirstOrDefault());
            item.Titles.Add(title);
            item.Roles.Add(role);
            item.Powers.Add(power);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/User/Delete/5

        public ActionResult Delete(int id)
        {
            User u = DB.Users.Find(id);
            DB.Users.Remove(u);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Admin/User/Delete/5

        [HttpPost]
        public ActionResult Delete(User u)
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
