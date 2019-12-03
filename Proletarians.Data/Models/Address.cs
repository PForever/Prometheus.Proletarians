using Microsoft.EntityFrameworkCore;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Address
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Build { get; set; }
        public string Room { get; set; }
        public int PostIndex { get; set; }
    }
}
