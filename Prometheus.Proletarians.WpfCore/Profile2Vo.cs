using FluentValidation;
using Prometheus.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Binding;
using Proletarians.Data.Models;
using ReactiveUI.Fody.Helpers;

namespace Prometheus.Proletarians.WpfCore
{
    public class Profile2Vo : ValidatedViewModel<Profile2Vo>
    {
        [Reactive] public string SomeProperty { get; set; }
        public IObservableCollection<Profile> Profiles { get; set; }

        public Profile2Vo() : base(new Profile2Validator())
        {

        }
    }
    class Profile2Validator : AbstractValidator<Profile2Vo>
    {
        public Profile2Validator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.SomeProperty).NotEmpty().Must(v => char.IsUpper(v[0]));
        }
    }
}
