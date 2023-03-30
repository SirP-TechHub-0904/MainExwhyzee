using MainExwhyzee.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MainExwhyzee.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<Profile, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WDAccount> WDAccounts { get; set; }
        public DbSet<WDSubAccount> SubAccounts { get; set; }
        public DbSet<Agsmis> Agsmiss { get; set; }
       
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=SQL5105.site4now.net;Database=db_a440e4_notification;User Id=db_a440e4_notification_admin;Password=Admin@123;MultipleActiveResultSets=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}