

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
using ReactiveUI;

namespace Proletarians.Data.Models
{
    [Owned]
    public class PhoneNumber : BaseVo<PhoneNumber>
    {
        private int? _contryCode;
        private int? _regionCode;
        private int? _number;

        public int? ContryCode
        {
            get => _contryCode;
            protected set => this.RaiseAndSetIfChanged(ref _contryCode, value);
        }

        public int? RegionCode
        {
            get => _regionCode;
            protected set => this.RaiseAndSetIfChanged(ref _regionCode, value);
        }

        public int? Number
        {
            get => _number;
            protected set => this.RaiseAndSetIfChanged(ref _number, value);
        }

        public PhoneNumber(int? contryCode, int? regionCode, int? number) : this()
        {
            ContryCode = contryCode;
            RegionCode = regionCode;
            Number = number;
        }
        protected PhoneNumber() : base(new PhoneNumberValidator()) { }
        public override string ToString() => $"{ContryCode}{RegionCode}{Number}";
    }

    class PhoneNumberValidator : AbstractValidator<PhoneNumber>
    {
        public PhoneNumberValidator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.ContryCode).NotNull().Equal(7).WithMessage("Указанный код страны не поддерживается");
            RuleFor(x => x.RegionCode).NotNull().InclusiveBetween(100, 999).WithMessage("Указанный код региона не поддерживается");
            RuleFor(x => x.Number).NotNull().InclusiveBetween(1000, 999_99_99).WithMessage("Номер телефона не соответствует заданному диапазону");
        }
    }
}
