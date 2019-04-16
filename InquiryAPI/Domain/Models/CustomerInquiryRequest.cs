using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class CustomerInquiryRequest
    {
        [DigitsLength(10)]
        public long? CustomerID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
