
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
using ReactiveUI;

namespace Proletarians.Data.Models
{
    public class Profile : BaseVo<Profile>
    {
        public Guid Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => this.RaiseAndSetIfChanged(ref _firstName, value);
        }

        public string MiddleName
        {
            get => _middleName;
            set => this.RaiseAndSetIfChanged(ref _middleName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => this.RaiseAndSetIfChanged(ref _lastName, value);
        }

        public string Alias
        {
            get => _alias;
            set => this.RaiseAndSetIfChanged(ref _alias, value);
        }

        private Contacts _contacts;
        private Guid _id;
        private string _alias;
        private string _lastName;
        private string _middleName;
        private string _firstName;
        private ParticipantStatus _participantStatus;
        private OrganizationStatus _organizationStatus;
        private Relation _relation;
        private SotialStatus _sotialStatus;
        private Acquaintance _acquaintance;
        private string _additionalInformations;
        private AgeCategory _ageCategory;

        public Contacts Contacts
        {
            get => _contacts;
            set => RiseAndSubscribeIfChanged(ref _contacts, value);
        }

        public AgeCategory AgeCategory
        {
            get => _ageCategory;
            //Todo BaseVo
            set => this.RaiseAndSetIfChanged(ref _ageCategory, value);
        }

        public string AdditionalInformations
        {
            get => _additionalInformations;
            set => this.RaiseAndSetIfChanged(ref _additionalInformations, value);
        }

        public Acquaintance Acquaintance
        {
            get => _acquaintance;
            set => this.RaiseAndSetIfChanged(ref _acquaintance, value);
        }

        public SotialStatus SotialStatus
        {
            get => _sotialStatus;
            set => this.RaiseAndSetIfChanged(ref _sotialStatus, value);
        }

        public Relation Relation
        {
            get => _relation;
            set => this.RaiseAndSetIfChanged(ref _relation, value);
        }

        public OrganizationStatus OrganizationStatus
        {
            get => _organizationStatus;
            set => this.RaiseAndSetIfChanged(ref _organizationStatus, value);
        }

        public ParticipantStatus ParticipantStatus
        {
            get => _participantStatus;
            set => this.RaiseAndSetIfChanged(ref _participantStatus, value);
        }

        public Profile() : base(new ProfileValidator())
        {
            Contacts = new Contacts();
            Acquaintance = new Acquaintance();
        }
    }

    class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.FirstName).Must(CheckName).WithMessage("Некорректное имя")/*.NotEmpty().Must(v => char.IsUpper(v[0]))*/;
            RuleFor(x => x.LastName).Must(CheckName).WithMessage("Некорректное имя")/*.NotEmpty().Must(v => char.IsUpper(v[0]))*/;
            RuleFor(x => x.MiddleName).Must(CheckName).WithMessage("Некорректное имя")/*.NotEmpty().Must(v => char.IsUpper(v[0]))*/;
            RuleFor(x => x.Contacts).SetValidator(new InnerValidator());
        }

        bool CheckName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && char.IsUpper(name[0]);
        }
    }
}
