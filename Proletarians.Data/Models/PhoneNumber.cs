

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace Proletarians.Data.Models
{
    [Owned]
    public class PhoneNumber
    {
        public int ContryCode { get; set; }
        public int RegionCode { get; set; }
        public int Number { get; set; }
        public override string ToString() => $"+{ContryCode}{FormatReionCode(RegionCode)}{FormatNumber(Number)}";
        private string FormatReionCode(int regionCode)
        {
            switch (regionCode)
            {
                case 0: return $" (";
                case var _ when regionCode < 100: return $" ({regionCode}";
                default : return $" ({regionCode})";
            }
        }

        private object FormatNumber(int number)
        {
            switch (number)
            {
                case var _ when number < 10: return $" {number:#}";
                case var _ when number < 100: return $" {number:##}";
                case var _ when number < 1000: return $" {number:###-}";
                case var _ when number < 10000: return $" {number:###-#}";
                case var _ when number < 100000: return $" {number:###-##-}";
                case var _ when number < 1000000: return $" {number:###-##-#}";
                case var _ when number < 10000000: return $" {number:###-##-##}";
                default: return $"{number}";
            }
        }
    }
}
