using System;

namespace Proletarians.Data.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
        public ResponsrbleField ResponsrbleField { get; set; }
    }
}
