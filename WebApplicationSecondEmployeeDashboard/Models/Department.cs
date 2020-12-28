using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Type your Department Name")]
        [Display(Name = "Dept Name")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public bool Show { get; set; } = true;
    }
}