using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Prometheus.Infrastructure;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Address : BaseVo<Address>
    {
        //TODO сделать неизменяемым
        public string Country { get; protected set; }
        public string Region { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Build { get; protected set; }
        public string Room { get; protected set; }
        public int PostIndex { get; protected set; }

        public Address(string country, string region, string city, string street, string build, string room, int postIndex) : this()
        {
            Country = country;
            Region = region;
            City = city;
            Street = street;
            Build = build;
            Room = room;
            PostIndex = postIndex;
        }
        protected Address() : base(new AddressValidator())
        {
        }
    }

    class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            
        }
    }
}
