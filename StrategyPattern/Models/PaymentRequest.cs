using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    public class PaymentRequest
    {
        public string PaymentMethod { get; set; } = string.Empty;
        public required PaymentDetails PaymentDetails { get; set; }
    }
}