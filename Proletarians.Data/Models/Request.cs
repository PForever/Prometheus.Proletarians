
using System;

namespace Proletarians.Data.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Interval Interval { get; set; }
        public OrganizationProfile Candidate { get; set; }
    }
}
