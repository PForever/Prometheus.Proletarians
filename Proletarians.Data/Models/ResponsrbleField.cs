
using System;
using System.Collections.Generic;

namespace Proletarians.Data.Models
{
    public class ResponsrbleField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OrganizationProfile Organizer { get; set; }
        public ICollection<Assign> Assigns { get; set; }
    }
}
