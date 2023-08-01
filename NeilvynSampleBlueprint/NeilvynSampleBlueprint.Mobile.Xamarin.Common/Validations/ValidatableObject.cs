using NeilvynSampleBlueprint.Mobile.Common.Localization;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels.Base;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Validations
{
    public class ValidatableObject<T> : NotifyPropertyChanged, IValidity
    {
        private List<string> _errors;
        private string _firstError;
        private T _value;
        private bool _isValid;
        private ValidationState _validationState;
        private bool _isRequired;

        public event EventHandler<T> ValueChanged;

        public List<IValidationRule<T>> Validations { get; }

        public bool IsRequired
        {
            get => _isRequired;
            set => SetProperty(ref _isRequired, value);
        }

        public List<string> Errors
        {
            get => _errors;
            set => SetProperty(ref _errors, value);
        }

        public string FirstError
        {
            get => _firstError;
            set => SetProperty(ref _firstError, value);
        }

        public T Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value, () => ValueChanged?.Invoke(this, value));
                if (value is string nValue && !string.IsNullOrEmpty(nValue))
                {
                    Validate();
                }
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set => SetProperty(ref _isValid, value);
        }

        public ValidationState ValidationState
        {
            get => _validationState;
            set => SetProperty(ref _validationState, value);
        }

        public ValidatableObject()
        {
            _isValid = false;
            _errors = new List<string>();
            Validations = new List<IValidationRule<T>>();
            ValidationState = ValidationState.NotValidated;
        }

        public void AddValidation(IValidationRule<T> validationRule)
        {
            Validations.Add(validationRule);
        }

        public bool Validate()
        {
            Errors.Clear();

            if (IsRequired && (Value == null
                || (Value is string strValue && string.IsNullOrEmpty(strValue))
                || (Value is IEnumerable enumerable && !enumerable.OfType<object>().Any())))
            {
                Errors.Add(AppResources.ValidationMessage_RequiredField);
            }
            else
            {
                var errors = Validations.Where(v => !v.Check(Value)).Select(v => v.ValidationMessage);

                Errors = errors.ToList();
            }

            FirstError = Errors.FirstOrDefault();
            IsValid = !Errors.Any();
            ValidationState = IsValid ? ValidationState.Valid : ValidationState.Invalid;

            return IsValid;
        }
    }
}
