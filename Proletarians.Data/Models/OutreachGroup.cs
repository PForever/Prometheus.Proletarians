
using System;
using System.Collections.Generic;

namespace Proletarians.Data.Models
{
    public class OutreachGroup
    {
        public Guid Id { get; set; }
        public Interval Interval { get; set; }
        public Location Location { get; set; }
        public OrganizationProfile Responsible { get; set; }
        public ICollection<OrganizationProfile> Group { get; set; }
    }
}
