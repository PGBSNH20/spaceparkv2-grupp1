using Logic.SpacePark;
using SpaceApi.Models;
using System;
using System.Linq;

namespace Logic
{
    public class PaymentActions
    {
        public void Pay(Parking parking)
        {
            Console.Clear();
            Console.WriteLine("Using swish to pay...");
            
            Payment pay = new Payment();
            pay.Amount = parking.Fee;
            pay.User = parking.ParkedBy;
            pay.PayDate = DateTime.Now;

            var spaceApi = new SpaceParkApi();
            spaceApi.AddPay(pay);
            
            Console.WriteLine("Payment successful");
            Console.WriteLine($"Payment By: {pay.User}. Amount: {pay.Amount} credits. Payment Date: {pay.PayDate}");
            Console.ReadKey();
        }
        public void Receipts()
        {
            string name = StandardMessages.NameReader();
            var spaceApi = new SpaceParkApi();
            var payments = spaceApi.GetReceipts(name);

            if (payments.Result != null)
            {
                if (!payments.Result.Any())
                {
                    Console.WriteLine("No receipts found.");
                }
                else
                {
                    foreach (var r in payments.Result)
                    {
                        Console.WriteLine($"Payment By: {r.User}. Amount: {r.Amount} credits. Payment Date: {r.PayDate}");
                    }
                }
            }
            else
            {
                StandardMessages.NotAllowedMessage();
            }
                Console.ReadKey();
        }
    }
}
