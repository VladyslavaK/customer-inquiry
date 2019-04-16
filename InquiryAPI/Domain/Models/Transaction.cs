using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using static Domain.Models.Enums;

namespace Domain.Models
{
    public class Transaction
    {
        public long TransactionID { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
    }
}
