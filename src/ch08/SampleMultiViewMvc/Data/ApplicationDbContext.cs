using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleMultiViewMvc.Models;

namespace SampleMultiViewMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Person> Person { get; set; }

        public async void MakeRoles()
        {
            var store = new RoleStore<IdentityRole>(this);
            if (this.Roles.Count() == 0)
            {
                await store.CreateAsync(new IdentityRole("Normal"));
                await store.CreateAsync(new IdentityRole("Administrator"));
                await SaveChangesAsync();
            }
        }
    }

    public class Seader
    {
        public static async void Initialize(ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            if (context.Roles.Count() == 0)
            {
                await store.CreateAsync(new IdentityRole("Normal"));
                await store.CreateAsync(new IdentityRole("Administrator"));
                await context.SaveChangesAsync();
            }

        }
    }
}