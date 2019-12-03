using System;

namespace Proletarians.Data.Models
{
    public class InvitationProfileResult
    {
        public Guid Id { get; set; }
        public InvitationProfile InvitationProfile { get; set; }
        public OrganizationProfile Caller { get; set; }
        public InvitationResult Result { get; set; }
        public string Discription { get; set; }
    }
}
