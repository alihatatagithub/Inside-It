using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    public enum TaskState
    {
        Done,
        NotDone
    }
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskState TaskState { get; set; }



        public string EmployeeID { get; set; }
        public Employee Employee { get; set; }


        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}