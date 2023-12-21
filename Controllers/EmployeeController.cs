using MvcHtmlHelper.Models;
using MvcPureHtml.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcHtmlHelper.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDb db;

        public EmployeeController()
        {
            db = new CompanyDb();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var emps = db.Employees.Include(ee => ee.Department).ToList();
            return View(emps);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var depts = db.Departments.ToList();
            ViewBag.depts = new SelectList(depts, "Dept_Id", "Dept_Name", 2);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int Emp_Id)
        {
            var emp = db.Employees.FirstOrDefault(ww => ww.Emp_Id == Emp_Id);
            var depts = db.Departments.ToList();
            ViewBag.depts = new SelectList(depts, "Dept_Id", "Dept_Name");
            return View(emp);
        }

        [HttpPost]
        public ActionResult edit( Employee employee)
        {
            ModelState.Remove("CPwd");
            ModelState.Remove("Pwd");
            if (ModelState.IsValid)
            {
                db.Employees.AddOrUpdate(employee);
                try
                {
                    db.SaveChanges();
                }
                catch(DbEntityValidationException ex)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


    }
}