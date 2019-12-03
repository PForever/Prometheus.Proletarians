

using System;

namespace Proletarians.Data.Models
{
    public class RequestResult
    {
        public Guid Id { get; set; }
        public Request Request { get; set; }
        public RequestResultState State { get; set; }
        public Event Event { get; set; }
        public OrganizationProfile Operator { get; set; }
        public string Comment { get; set; }
    }
}
