using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Enums
    {
        public enum TransactionStatus
        {
            Success,
            Failed,
            Cancelled
        }

        public enum CurrencyCode
        {
            USD,
            JPY,
            THB,
            SGD
        }

    }
}
