using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "09e68d45-e2d4-4aec-9e14-f722c4917e02",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                new IdentityRole
                {
                    Id = "35dc4233-3849-419e-96c8-70dccfca8703",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                },
                new IdentityRole
                {
                    Id = "d59b15cc-3039-4b05-ad57-183168d64072",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                }
                
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "0a98afa1-cd62-4929-9e0c-444917846e39",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1950,12,12)
                }
             );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> 
                { 
                    RoleId = "d59b15cc-3039-4b05-ad57-183168d64072",
                    UserId = "0a98afa1-cd62-4929-9e0c-444917846e39",
                }
            );
        }

       

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
