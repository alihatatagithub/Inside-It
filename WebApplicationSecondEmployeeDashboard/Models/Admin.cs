using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}