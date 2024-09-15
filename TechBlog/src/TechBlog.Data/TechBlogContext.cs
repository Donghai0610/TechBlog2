using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Domain.Content;
using TechBlog.Core.Domain.Identity;

namespace TechBlog.Data
{
    public class TechBlogContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public TechBlogContext(DbContextOptions<TechBlogContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostActivityLog> ActivityLogs { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PostInSeries> PostSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });




        }
      /*  public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added|| e.State== EntityState.Modified
            );
            foreach(var entityEntry in entries)
            {
               var dateCreateProp = entityEntry.Entity.GetType().GetProperty("DateCreated");
                if ( entityEntry.State == EntityState.Added && dateCreateProp != null)
                {
                    dateCreateProp.SetValue(entityEntry.Entity, DateTime.Now);
                }
              *//*  var modifieDateProp = entityEntry.Entity.GetType().GetProperty("ModifiedDate");
                if (entityEntry.State == EntityState.Modified && modifieDateProp != null)
                {
                    modifieDateProp.SetValue(entityEntry.Entity, DateTime.Now);
                }*//*
            }
            return base.SaveChangesAsync( cancellationToken);
        }*/

    }
}
