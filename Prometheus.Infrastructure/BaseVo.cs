using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using DynamicData.Binding;
using FluentValidation;
using FluentValidation.Results;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Prometheus.Infrastructure
{
    public class BaseVo<T> : ReactiveObject, IValidatedObject<T>, INotifyDataErrorInfo
        where T : BaseVo<T>
    {
        private ValidationResult _validationResult;
        private ILookup<string, ValidationFailure> _errors;
        [NotMapped] protected T This { get; }
        [NotMapped] public extern IList<ValidationFailure> Errors { [ObservableAsProperty] get; }
        [NotMapped] public extern bool IsValid { [ObservableAsProperty] get; }
        [NotMapped] public IObservable<ValidationResult> ValidationResultChanged { get; }
        public BaseVo(AbstractValidator<T> validator)
        {
            This = (T)this;
            Validator = validator;
            Changed
                .Where(p =>
                    p.PropertyName != nameof(ValidationResult) &&
                    p.PropertyName != nameof(Errors) &&
                    p.PropertyName != nameof(IsValid))
                .Subscribe(Revalidate);
            var obs = ValidationResultChanged = this.WhenAnyValue(x => x.ValidationResult);
            Revalidate();
            obs.Select(x => x.Errors).Select(x => x.ToList())
                .ToPropertyEx(this, x => x.Errors);
            obs.Select(x => x.IsValid).ToPropertyEx(this, x => x.IsValid);
        }



        public IEnumerable GetErrors(string propertyName) => _errors.Contains(propertyName) ? _errors[propertyName].Select(e => e.ErrorMessage) : null;


        [NotMapped] public bool HasErrors { get; private set; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        [NotMapped] public AbstractValidator<T> Validator { get; }
        [NotMapped]
        public ValidationResult ValidationResult
        {
            get => _validationResult;
            private set
            {
                this.RaisePropertyChanging();
                _validationResult = value;
                _errors = _validationResult.Errors.ToLookup(e => e.PropertyName);
                HasErrors = !_validationResult.IsValid;
                RiseIfHasError(_validationResult);
                this.RaisePropertyChanged();
            }
        }

        protected virtual TProperty RiseAndSubscribeIfChanged<TProperty>(ref TProperty backingField, TProperty newValue, [CallerMemberName] string propertyName = null)
            where TProperty : IValidateChanged
        {
            Contract.Requires(propertyName != null);

            if (EqualityComparer<TProperty>.Default.Equals(backingField, newValue)) return newValue;

            this.RaisePropertyChanging(propertyName);
            Describe(backingField);
            backingField = newValue;
            Subscribe(newValue);
            this.RaisePropertyChanged(propertyName);
            return newValue;
        }

        protected virtual IObservableCollection<TProperty> RiseAndSubscribeIfChanged<TProperty>(ref IObservableCollection<TProperty> backingField, IObservableCollection<TProperty> newValue, [CallerMemberName] string propertyName = null)
            where TProperty : IValidateChanged
        {
            Contract.Requires(propertyName != null);

            if (EqualityComparer<IObservableCollection<TProperty>>.Default.Equals(backingField, newValue)) return newValue;

            this.RaisePropertyChanging(propertyName);
            Describe<TProperty, IObservableCollection<TProperty>>(backingField);
            backingField = newValue;
            Subscribe<TProperty, IObservableCollection<TProperty>>(newValue);
            this.RaisePropertyChanged(propertyName);
            return newValue;
        }

        private readonly IDictionary<IValidateChanged, IDisposable> _subscribedProperty = new Dictionary<IValidateChanged, IDisposable>();
        private readonly IDictionary<IEnumerable, IDisposable> _subscribedPropertyCollection = new Dictionary<IEnumerable, IDisposable>();
        protected void Subscribe<TProperty>(TProperty property)
            where TProperty : IValidateChanged
        {
            if (property != null && !_subscribedProperty.ContainsKey(property))
            {
                _subscribedProperty.Add(property, property.ValidationResultChanged.Subscribe(x => Revalidate()));
            }
        }
        protected void Subscribe<TProperty, TCollection>(TCollection properties)
            where TProperty : IValidateChanged
            where TCollection : IObservableCollection<TProperty>
        {
            if (properties != null && !_subscribedPropertyCollection.ContainsKey(properties))
            {
                _subscribedPropertyCollection.Add(properties, properties.ActOnEveryObject<TProperty, IObservableCollection<TProperty>>(Subscribe, Describe));
            }
        }
        protected void Describe<TProperty, TCollection>(TCollection properties)
            where TProperty : IValidateChanged
            where TCollection : IObservableCollection<TProperty>
        {
            if (properties != null && _subscribedPropertyCollection.ContainsKey(properties))
            {
                _subscribedPropertyCollection[properties].Dispose();
                _subscribedPropertyCollection.Remove(properties);
            }
        }
        protected void Describe<TProperty>(TProperty property)
            where TProperty : IValidateChanged
        {
            if (property != null && _subscribedProperty.ContainsKey(property))
            {
                _subscribedProperty[property].Dispose();
                _subscribedProperty.Remove(property);
                Revalidate();
            }
        }



        private void RiseIfHasError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var propertyName = error.PropertyName.IndexOf('.') is var i && i != -1 ? error.PropertyName.Substring(0, i) : error.PropertyName;
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void Revalidate(IReactivePropertyChangedEventArgs<IReactiveObject> x) => ValidationResult = Validator.Validate(This/*, x.PropertyName*/);
        public void Revalidate() => ValidationResult = Validator.Validate(This);
        [NotMapped] IValidator IValidatedObject.Validator => Validator;
    }

    public interface IValidatedObject<T> : IValidateChanged, IValidatedObject
    {
        AbstractValidator<T> Validator { get; }
    }
    public interface IValidatedObject : IValidateChanged
    {
        IValidator Validator { get; }
    }

    public interface IValidateChanged : IReactiveObject
    {
        public IObservable<ValidationResult> ValidationResultChanged { get; }
        public ValidationResult ValidationResult { get; }
    }

    public class InnerValidator : AbstractValidator<IValidateChanged>
    {
        public InnerValidator()
        {
            RuleFor(x => x).Must(x => x.ValidationResult.IsValid).WithMessage(x => string.Join(Environment.NewLine,
                x.ValidationResult.Errors.Select(e => $"{e.PropertyName} : {e.ErrorMessage}")));
        }
    }
}
