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
    public class DivisionsController : Controller
    {
        private myContext myConn = new myContext();
        // GET: Divisions
        public ActionResult Index()
        {
            var readdata = myConn.Divisions.Include("Department").ToList();
            return View(readdata);
        }

        // GET: Divisions/Details/5
        public ActionResult Details(int id)
        {
            return View(myConn.Divisions.Find(id));
        }

        // GET: Divisions/Create
        public ActionResult Create()
        {
            ViewBag.id_department = new SelectList(myConn.Departments, "Id", "Name");
            return View();
        }

        // POST: Divisions/Create
        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                myConn.Divisions.Add(division);
                myConn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.id_department = new SelectList(myConn.Departments, "Id", "Name", division.Name);
                return View();
            }
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id_department = new SelectList(myConn.Departments, "Id", "Name");
            return View(myConn.Divisions.Find(id));
        }

        // POST: Divisions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Division division)
        {
            try
            {
                myConn.Entry(division).State = EntityState.Modified;
                myConn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.id_department = new SelectList(myConn.Departments, "Id", "Name", division.Name);
                return View();
            }
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(int id)
        {
            return View(myConn.Divisions.Find(id));
        }

        // POST: Divisions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Division division)
        {
            try
            {
                var Delete = myConn.Divisions.Where(S => S.Id == id).FirstOrDefault();
                myConn.Divisions.Remove(Delete);
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
