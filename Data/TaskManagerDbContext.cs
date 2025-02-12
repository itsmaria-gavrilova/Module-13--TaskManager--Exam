using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Data.Models;
using Task = Task_Manager.Data.Models.Task;
using static Task_Manager.Common.AdminUser;

namespace Task_Manager.Data
{
    public class TaskManagerDbContext : IdentityDbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public IdentityUser AdminUser {  get; set; }
        private IdentityUser TestUser{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
            // Define the many-to-many relationship between Employee and Task via EmployeeTask
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(et => new { et.EmployeeID, et.TaskID });

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTasks)
                .HasForeignKey(et => et.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade); // When an Employee is deleted, related EmployeeTasks are deleted

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(et => et.Task)
                .WithMany(t => t.EmployeeTasks)
                .HasForeignKey(et => et.TaskID)
                .OnDelete(DeleteBehavior.Cascade); // When a Task is deleted, related EmployeeTasks are deleted
        }
        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "employee@mail.com",
                NormalizedUserName = "employee@mail.com",
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "employee");
            AdminUser = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin");

            modelBuilder.Entity<IdentityUser>()
                .HasData(TestUser, AdminUser);
        }
    }
}
