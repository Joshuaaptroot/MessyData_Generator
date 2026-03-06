using System;

namespace MessyData_Generator.Models
{
    public class CanonicalEvent
    {
        public Guid EventId { get; set; }

        public string OrderId { get; set; }

        public int CustomerId { get; set; }

        public EventType EventType { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}