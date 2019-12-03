
using System;

namespace Proletarians.Data.Models
{
    public class InvitationProfile
    {
        public Guid Id { get; set; }
        public Profile Person { get; set; }
        public int Round { get; set; }
        public Invitation Invitation { get; set; }
    }
}
