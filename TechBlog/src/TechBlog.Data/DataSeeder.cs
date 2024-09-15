using Microsoft.AspNetCore.Identity;
using TechBlog.Core.Domain.Identity;

namespace TechBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(TechBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name =" ADMIN",
                    NormalizedName = "ADMIN",
                    DisplayName = "Root Admin"
                });
            }
            if (!context.Roles.Any())
            {
               var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Root",
                    LastName = "Admin",
                    Email = "admin@fpt.edu.vn",
                    NormalizedEmail = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now,

                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                await context.Users.AddAsync(user);
                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId
                });
                await context.SaveChangesAsync();   
            }

        }



    }
}
