using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Data
{
    public class PaymentsDataStore : IPaymentsDataStore
    {
        private readonly SpaceContext _context;

        public PaymentsDataStore(SpaceContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetPaymentFromName(string name)
        {
            return await _context.Payments.Where(p => p.User == name).ToListAsync();
        }
        public async Task<Payment> AddPayment(Payment payment)
        {
            try
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return payment;
            }
            catch
            {
                return null;
            }
        }
    }
}
