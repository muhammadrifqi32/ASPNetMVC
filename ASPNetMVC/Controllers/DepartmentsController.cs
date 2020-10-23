using ASPNetMVC.Context;
using ASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private myContext myConn = new myContext();
        public ActionResult Index()
        {
            return View(myConn.Departments.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(myConn.Departments.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                myConn.Departments.Add(department);
                myConn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(myConn.Departments.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                myConn.Entry(department).State = EntityState.Modified;
                myConn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(myConn.Departments.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int Id, Department department)
        {
            try
            {
                var Delete = myConn.Departments.Where(S => S.Id == Id).FirstOrDefault();
                myConn.Departments.Remove(Delete);
                myConn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}