
using System;
using System.Collections.Generic;

namespace Proletarians.Data.Models
{
    public class Outreach
    {
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public ICollection<OutreachGroup> Groups { get; set; }
    }
}
