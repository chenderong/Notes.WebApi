using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Notes.WebApi.Authorization.Roles;
using Notes.WebApi.Authorization.Users;
using Notes.WebApi.MultiTenancy;
using Notes.WebApi.Core.Blogs;

namespace Notes.WebApi.EntityFrameworkCore
{
    public class WebApiDbContext : AbpZeroDbContext<Tenant, Role, User, WebApiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Blog> Blogs { get; set; }

    }
}
