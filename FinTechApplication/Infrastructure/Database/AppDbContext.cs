using FinTechApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinTechApplication.Infrastructure.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser>? Users { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
    }
    
}
