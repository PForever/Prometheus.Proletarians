

using System;

namespace Proletarians.Data.Models
{
    public class OrganizationProfile
    {
        public Guid Id { get; set; }
        public Profile Person { get; set; }
        public OrgProfileState State { get; set; }
    }
}
