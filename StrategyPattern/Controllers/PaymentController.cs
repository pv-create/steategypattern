using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IDictionary<string, IPaymentStrategy> _paymentStrategies;

        public PaymentController(IDictionary<string, IPaymentStrategy> paymentStrategies)
        {
            _paymentStrategies = paymentStrategies;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
        {
            if (!_paymentStrategies.TryGetValue(request.PaymentMethod, out var strategy))
            {
                return BadRequest("Invalid payment method");
            }

            var result = await strategy.ProcessPayment(request.PaymentDetails);
            return Ok(result);  
        }
    }
}