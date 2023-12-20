using MvcHtmlHelper.Models;
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
    }
}