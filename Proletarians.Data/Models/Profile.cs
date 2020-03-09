
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentValidation;
using Prometheus.Infrastructure;

namespace Proletarians.Data.Models
{
    public class Profile : BaseVo<Profile>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        private Contacts _contacts;
        public Contacts Contacts
        {
            get => _contacts;
            set => RiseAndSubscribeIfChanged(ref _contacts, value);
        }

        public AgeCategory AgeCategory { get; set; }
        public string AdditionalInformations { get; set; }
        public Acquaintance Acquaintance { get; set; }
        public SotialStatus SotialStatus { get; set; }
        public Relation Relation { get; set; }
        public OrganizationStatus OrganizationStatus { get; set; }
        public ParticipantStatus ParticipantStatus { get; set; }
        public Profile() : base(new ProfileValidator())
        {
        }
    }

    class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.Contacts).SetValidator(new InnerValidator());
        }
    }
}
