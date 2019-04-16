using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomerContext _context;

        public CustomersRepository(CustomerContext context)
        {
            _context = context;

        }
        public async Task<Customer> GetCustomersTransactionsAsync(CustomerInquiryRequest request)
        {
            return await _context.Customers.Include(c => c.Transactions).FirstOrDefaultAsync<Customer>(c => c.CustomerID == request.CustomerID.Value 
                                                || c.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase));
        }

        #region IDisposable Support
        private bool disposedValue = false; 
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
