using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CustomerInquiryRequest
    {
        public long CustomerID { get; set; }
        public string Email { get; set; }
    }
}
