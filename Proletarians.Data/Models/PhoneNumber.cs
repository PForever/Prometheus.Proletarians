

using Microsoft.EntityFrameworkCore;

namespace Proletarians.Data.Models
{
    [Owned]
    public class PhoneNumber
    {
        public int ContryCode { get; set; }
        public int RegionCode { get; set; }
        public int Number { get; set; }
    }
}
