using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Enums;

namespace Domain
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
