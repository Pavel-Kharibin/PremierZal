using System;

namespace PremierZal.Data.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public int SessionId { get; set; }
        public int TicketsCount { get; set; }
        public DateTime Sold { get; set; }
    }
}