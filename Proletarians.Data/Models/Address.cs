using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using DynamicData.Binding;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Prometheus.Infrastructure;
using ReactiveUI;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Address : BaseVo<Address>
    {
        private string _country;
        private int _postIndex;
        private string _room;
        private string _build;
        private string _street;
        private string _city;
        private string _region;

        public override string ToString()
        {
            return $"{Country}, {Region}, {City}";
        }

        private ObservableAsPropertyHelper<string> _displayValue;
        [NotMapped]
        public string DisplayValue => _displayValue.Value;

        //TODO сделать неизменяемым
        public string Country
        {
            get => _country;
            set => this.RaiseAndSetIfChanged(ref _country, value);
        }

        public string Region
        {
            get => _region;
            set => this.RaiseAndSetIfChanged(ref _region, value);
        }

        public string City
        {
            get => _city;
            set => this.RaiseAndSetIfChanged(ref _city, value);
        }

        public string Street
        {
            get => _street;
            set => this.RaiseAndSetIfChanged(ref _street, value);
        }

        public string Build
        {
            get => _build;
            set => this.RaiseAndSetIfChanged(ref _build, value);
        }

        public string Room
        {
            get => _room;
            set => this.RaiseAndSetIfChanged(ref _room, value);
        }

        public int PostIndex
        {
            get => _postIndex;
            set => this.RaiseAndSetIfChanged(ref _postIndex, value);
        }

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
        public Address() : base(new AddressValidator())
        {
            this.WhenAnyPropertyChanged().Select(x => x.ToString()).ToProperty(this, x => x.DisplayValue, out _displayValue);
        }
    }

    class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Region).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            //RuleFor(x => x.Build).NotEmpty();
            //RuleFor(x => x.Room).NotEmpty();
        }
    }
}
