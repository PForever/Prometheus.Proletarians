

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Proletarians.Data.Models
{
    [Owned]
    public class PhoneNumber : IDataErrorInfo
    {
        
        private int _contryCode;
        public int ContryCode
        {
            get => _contryCode; set
            {
                //if (!ValidateCountryCode(value)) throw new ArgumentException($"Неверный код страны {value}");
                _contryCode = value;
                Validate();
            }
        }

        private static bool ValidateCountryCode(int value) => value == 7;
        private int _regionCode;
        private int _number;

        public int RegionCode
        {
            get => _regionCode; set
            {
                //if (!ValidateRegionCode(value)) throw new ArgumentException($"Неверный код региона {value}");
                _regionCode = value;
                Validate();
            }
        }

        private static bool ValidateRegionCode(int value) => value >= 100 && value <= 999;
        public int Number
        {
            get => _number; set
            {
                //if (!ValidateNumber(value)) throw new ArgumentException($"Неверный номер {value}");
                _number = value;
                Validate();
            }
        }
        private static bool ValidateNumber(int value) => value >= 100_00_00 && value <= 999_99_99;
        private void Validate([CallerMemberName] string propertyName = "") => _validationErrorMessaged.AddOrUpdate(propertyName, k => this[k], (k, _) => this[k]);
        private ConcurrentDictionary<string, string> _validationErrorMessaged = new ConcurrentDictionary<string, string>();
        protected PhoneNumber()
        {

        }
        public PhoneNumber(int contryCode, int regionCode, int number)
        {
            ContryCode = contryCode;
            RegionCode = regionCode;
            Number = number;
        }

        [NotMapped]
        public string Error => string.Join(Environment.NewLine, _validationErrorMessaged.Values.Where(m => !string.IsNullOrEmpty(m)));

        public string this[string columnName] => columnName switch
        {
            nameof(ContryCode) when !ValidateCountryCode(ContryCode) => $"Неверный код страны {ContryCode}",
            nameof(RegionCode) when !ValidateRegionCode(RegionCode) => $"Неверный код региона {RegionCode}",
            nameof(Number) when !ValidateNumber(Number) => $"Неверный код номер {Number}",
            _ => String.Empty
        };

        public override string ToString() => $"+{ContryCode}{FormatReionCode(RegionCode)}{FormatNumber(Number)}";
        private string FormatReionCode(int regionCode) => regionCode switch
        {
            0 => $" (",
            _ when regionCode < 100 => $" ({regionCode}",
            _ => $" ({regionCode})",
        };

        private object FormatNumber(int number) => number switch
        {
            _ when number < 10 => $" {number:#}",
            _ when number < 100 => $" {number:##}",
            _ when number < 1000 => $" {number:###-}",
            _ when number < 10000 => $" {number:###-#}",
            _ when number < 100000 => $" {number:###-##-}",
            _ when number < 1000000 => $" {number:###-##-#}",
            _ when number < 10000000 => $" {number:###-##-##}",
            _ => $"{number}",
        };
    }
}
