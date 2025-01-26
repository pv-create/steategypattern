using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern.Models
{
    public class PaymentDetails
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}