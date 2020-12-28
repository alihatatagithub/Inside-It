using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool Show { get; set; } = true;
    }
}