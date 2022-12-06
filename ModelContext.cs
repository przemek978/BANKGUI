using BANK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BANK
{
    internal class ModelContext:DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
                : base(options) { }
        public Microsoft.EntityFrameworkCore.DbSet<User> users { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Account> accounts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Transaction> transacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\KCK\BANK\BANK\DATABASE\BankDB.mdf;Integrated Security=True");

            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\DATABASE\BankDB.mdf;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");

        }


    }
}
