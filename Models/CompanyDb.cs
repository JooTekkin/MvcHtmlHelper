using MvcPureHtml.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MvcHtmlHelper.Models
{
    public class CompanyDb : DbContext
    {

        public CompanyDb()
            : base("name=CompanyDb")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

}