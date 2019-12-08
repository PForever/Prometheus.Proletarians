using Microsoft.EntityFrameworkCore;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Contacts
    {
        [Notify]
        public PhoneNumber Phone { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set; }
    }
}
