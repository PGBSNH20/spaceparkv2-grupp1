using Microsoft.AspNetCore.Mvc;
using SpaceApi.Data;
using SpaceApi.Models;
using SpaceApi.SWAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsDataStore _paymentData;

        public PaymentsController(IPaymentsDataStore paymentData)
        {
            _paymentData = paymentData;
        }
        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            var result = await _paymentData.AddPayment(payment);

            if (result == null)
                return BadRequest();

            return CreatedAtAction("PostPayment", new { id = payment.Id }, payment);
        }
        // GET: api/Payments?personName=R2-D2
        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetPayments(string personName)
        {
            Results starWarsCharacter = PersonApi.GetCharacter(personName);
            if (starWarsCharacter == null) return NotFound();
            List<Payment> payments = await _paymentData.GetPaymentFromName(personName);
            if (payments.Count == 0)
                return NotFound();
            return Ok(payments);
        }
    }
}
