using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StrategyPattern.Models;

namespace StrategyPattern.Interfaces
{
    public interface IPaymentStrategy
    {
        Task<PaymentResult> ProcessPayment(PaymentDetails payment);
    }
}