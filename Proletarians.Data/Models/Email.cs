using Microsoft.EntityFrameworkCore;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Email
    {
        public string Alias { get; set; }
        public string Host { get; set; }
    }
}
