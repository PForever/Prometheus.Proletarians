using Microsoft.EntityFrameworkCore;
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
    [Owned]
    public class Contacts : BaseVo<Contacts>
    {
        private PhoneNumber _phone;
        private Email _email;
        private Address _address;

        public PhoneNumber Phone
        {
            get => _phone;
            set => RiseAndSubscribeIfChanged(ref _phone, value);
        }

        public Email Email
        {
            get => _email;
            set => RiseAndSubscribeIfChanged(ref _email, value);
        }

        public Address Address
        {
            get => _address;
            set => RiseAndSubscribeIfChanged(ref _address, value);
        }

        public Contacts() : base(new ContactsValidator()) { }
    }
    class ContactsValidator : AbstractValidator<Contacts>
    {
        public ContactsValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Phone).NotEmpty().SetValidator(new InnerValidator()).WithMessage("Контактный номер не указан или не корректен");
            RuleFor(x => x.Email).NotEmpty().SetValidator(new InnerValidator()).WithMessage("Контактный номер не указан или не корректен");
            RuleFor(x => x.Address).NotEmpty().SetValidator(new InnerValidator()).WithMessage("Контактный номер не указан или не корректен");
        }
    }
}
