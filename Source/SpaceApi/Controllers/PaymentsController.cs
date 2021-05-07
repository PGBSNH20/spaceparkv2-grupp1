using Microsoft.AspNetCore.Mvc;
using SpaceApi.Models;
using SpaceApi.SWAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public PaymentsController(SpaceContext context)
        {
            _context = context;
        }
        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            try
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
            }
            catch
            {
                return BadRequest();
            }

        }
        // GET: api/Payments?personName=R2-D2
        [HttpGet]
        public List<Payment> GetPayments(string personName)
        {
            Results starWarsCharacter = PersonApi.GetCharacter(personName);
            if (starWarsCharacter == null) return null;
            List<Payment> payments = new List<Payment>();
            payments = _context.Payments.Where(p => p.User == personName).ToList();
            return payments;
        }
    }
}
