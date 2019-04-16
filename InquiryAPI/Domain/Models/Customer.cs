using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Customer
    {
        public Customer()
        {
            Transactions = new List<Transaction>();
        }
        [DigitsLength(10)]
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }    
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
