using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbSeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var context = (CustomerContext)services
                .GetService(typeof(CustomerContext));
            using (context)
            {
                context.Database.EnsureCreated();
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        GetPredefinedCustomers());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<Customer> GetPredefinedCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {CustomerID = 1, CustomerName = "John Snow", Email="john@mail.com", MobileNumber = 1234567890 }
                ,new Customer() { CustomerID = 1234567890, CustomerName = "John Smith", Email="john.smith@mail.com", MobileNumber = 1234567890,
                    Transactions = new List<Transaction>()
                    {
                        new Transaction() {  Amount = 200, CurrencyCode = Enums.CurrencyCode.USD, TransactionDate = DateTime.Now, Status = Enums.TransactionStatus.Success }
                        ,new Transaction() { Amount = 100, CurrencyCode = Enums.CurrencyCode.THB, TransactionDate = DateTime.Now, Status = Enums.TransactionStatus.Cancelled }
                    }
                },
            };
        }
    }
}

