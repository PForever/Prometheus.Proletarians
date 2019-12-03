using System;
using System.Collections.Generic;

namespace Proletarians.Data.Models
{
    public class Invitation
    {
        public Guid Id { get; set; }
        public Event Event { get; set; }
        public Event Target { get; set; }
        public ReasonForCall ReasonForCall { get; set; }
        public ICollection<InvitationProfile> InvitationProfiles { get; set; }
    }
}
