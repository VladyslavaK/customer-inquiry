using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
