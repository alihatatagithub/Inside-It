using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplicationSecondEmployeeDashboard.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
            
    }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasRequired<Department>(s => s.Department)
           .WithMany(g => g.Employees)
           .HasForeignKey(s=>s.User)
           
           
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<Task>()
          .HasRequired<Project>(p => p.Project)
          .WithMany(t => t.Tasks)
          .HasForeignKey(p => p.ProjectId)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
         .HasRequired<Employee>(p => p.Employee)
         .WithMany(t => t.Tasks)
         .HasForeignKey(p => p.EmployeeID)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(e => e.Employee)
                .WithRequired(e => e.User);
               

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}