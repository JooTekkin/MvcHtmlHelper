using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcPureHtml.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Display(Name ="SSN")]
        [Column("ID")]
        [Key]
        public int Emp_Id {  get; set; }

        [Display(Name ="First Name :")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="you should fill it")]
        [StringLength(10,ErrorMessage ="below 10 chars")]
        public string Fname { get; set; }

        [Display(Name ="Last Name :")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "you should fill it")]
        [StringLength(10, ErrorMessage = "below 10 chars")]
        public string Lname { get; set; }

        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "you should fill it")]
        [RegularExpression("^[a-zA-Z0-9]{4,15}$", ErrorMessage = "between 4,15 contain nums and chars")]
        public string Pwd {  get; set; }

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^[a-zA-Z0-9]{4,15}$", ErrorMessage = "between 4,15 contain nums and chars")]
        [Compare("Pwd",ErrorMessage ="Dosen't match")]
        [NotMapped]
        public string CPwd {  get; set; }

        [Display(Name = "BirthDate :")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Bod { get; set; }

        [Display(Name = "Birth Hire :")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Boh { get; set;}

        [Display(Name = "Url Blog :")]
        [DataType(DataType.Url)]
        public string Url {  get; set; }

        [Display(Name = "E_mail :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Department:")]
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public virtual Department Department { get; set; }
    }
}