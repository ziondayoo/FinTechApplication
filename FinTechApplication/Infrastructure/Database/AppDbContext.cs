﻿using FinTechApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTechApplication.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
