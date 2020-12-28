using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    public enum ProjectState
    {
        Complete,
        NotComplete
    }
    public class Project
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public ProjectState ProjectState { get; set; }




    }
}