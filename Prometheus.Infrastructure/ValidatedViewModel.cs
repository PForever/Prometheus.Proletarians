using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Prometheus.Infrastructure
{
    public class ValidatedViewModel<T> : ReactiveObject, IValidatedViewModel
        where T : ValidatedViewModel<T>
    {
        private readonly T _instance;
        [NotMapped] public IObservable<string> PropertyChangingObservable { get; }
        [NotMapped] public IObservable<string> PropertyChangedObservable { get; }
        [NotMapped] public IObservable<ValidationResult> ValidationResultObservable { get; }
        public ValidatedViewModel(AbstractValidator<T> validationRules)
        {
            ValidationRules = validationRules;
            _instance = this as T ?? throw new Exception($"{this.ToString()} of type {this.GetType()} is not instance of {typeof(T)}");
            PropertyChangingObservable = Observable.FromEventPattern<PropertyChangingEventHandler, PropertyChangingEventArgs>(h => PropertyChanging += h, h => PropertyChanging -= h).Select(p => p.EventArgs.PropertyName);
            PropertyChangedObservable = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(h => PropertyChanged += h, h => PropertyChanged -= h).Select(p => p.EventArgs.PropertyName);
            PropertyChangedObservable/*.Throttle(TimeSpan.FromMilliseconds(100))*/.Where(p => p != nameof(Errors) && p != nameof(ValidationResult)).Subscribe(OnPropertyChanged);
            var obs = ValidationResultObservable = this.WhenAnyValue(x => x.ValidationResult);
            UpdateValidateResult();
            obs.Where(x => x != null).Select(x => x.Errors).ToPropertyEx(this, x => x.Errors);
        }

        [NotMapped] public bool HasErrors => !ValidationResult.IsValid;
        [NotMapped] protected AbstractValidator<T> ValidationRules { get; }

        private ValidationResult UpdateValidateResult() => ValidationResult = ValidationRules.Validate(_instance);
        private async Task<ValidationResult> UpdateValidateResultAsync() => ValidationResult = await ValidationRules.ValidateAsync(_instance);
        [NotMapped] public extern IList<ValidationFailure> Errors { [ObservableAsProperty]get; }
        [NotMapped] [Reactive] public ValidationResult ValidationResult { get; private set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName) => ValidationResult.Errors.Where(e => e.PropertyName == propertyName).Select(e => e.ErrorMessage);

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var oldMessages = ValidationResult.Errors.Where(e => e.PropertyName == propertyName).Select(e => e.ErrorCode).ToHashSet();
            UpdateValidateResult();
            var newMessages = ValidationResult.Errors.Where(e => e.PropertyName == propertyName).Select(e => e.ErrorCode);

            if (newMessages.Any(message => !oldMessages.Contains(message)))
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

            if (oldMessages.Any(message => !newMessages.Contains(message)))
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }

    interface IValidatedViewModel : INotifyDataErrorInfo
    {
        ValidationResult ValidationResult { get; }
    }
}