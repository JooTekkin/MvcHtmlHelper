using MvcHtmlHelper.Models;
using MvcPureHtml.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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


    }
}