
using System;
using System.Collections.Generic;

namespace Proletarians.Data.Models
{
    public class Manager
    {
        public Guid Id { get; set; }
        public OrganizationProfile Profile { get; set; }
        public ManagerState State { get; set; }
        public ICollection<Assign> Assigns { get; set; }
    }
}
