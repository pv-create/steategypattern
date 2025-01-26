using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.PaymentStrategies
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public Task<PaymentResult> ProcessPayment(PaymentDetails payment)
        {
            return Task.FromResult(new PaymentResult{Success = true});
        }
    }
}