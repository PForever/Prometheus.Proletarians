

using Microsoft.EntityFrameworkCore;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Acquaintance
    {
        public Period Period { get; set; }
        public Location Location { get; set; }
        public string Discription { get; set; }
    }
}
