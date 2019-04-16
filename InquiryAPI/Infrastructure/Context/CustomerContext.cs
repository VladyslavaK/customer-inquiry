using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Domain.Models.Enums;

namespace Infrastructure.Context
{
    public class CustomerContext : DbContext
    {
    
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany<Transaction>(t => t.Transactions);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerID)
                .ValueGeneratedNever();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.CurrencyCode)
                .HasConversion(
                c => c.ToString(),
                c => (CurrencyCode)Enum.Parse(typeof(CurrencyCode), c));

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion(
                c => c.ToString(),
                c => (TransactionStatus)Enum.Parse(typeof(TransactionStatus), c));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
