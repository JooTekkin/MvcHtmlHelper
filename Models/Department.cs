using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcPureHtml.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        public string Dept_Name {  get; set; }
        public int Code { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}