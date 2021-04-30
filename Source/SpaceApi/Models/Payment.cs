using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [MaxLength(50)] public string User { get; set; }
        public DateTime PayDate { get; set; }
    }
}
