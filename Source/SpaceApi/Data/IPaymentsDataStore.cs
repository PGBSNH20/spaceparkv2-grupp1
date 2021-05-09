using SpaceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceApi.Data
{
    public interface IPaymentsDataStore
    {
        Task<Payment> AddPayment(Payment payment);
        Task<List<Payment>> GetPaymentFromName(string name);
    }
}
