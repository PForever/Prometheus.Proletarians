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
    public class Contacts : IDataErrorInfo
    {
        private PhoneNumber _phone;


        public string this[string columnName] => columnName switch
        {
            nameof(Phone) => Phone?.Error ?? "Контактный адрес не указан",
            _ => string.Empty,
        };

        [Notify]
        public PhoneNumber Phone
        {
            get => _phone; set
            {
                _phone = value;
                Validate();
            }
        }
        public Email Email { get; set; }
        public Address Address { get; set; }
        private void Validate([CallerMemberName] string propertyName = "") => _validationErrorMessaged.AddOrUpdate(propertyName, k => this[k], (k, _) => this[k]);
        private ConcurrentDictionary<string, string> _validationErrorMessaged = new ConcurrentDictionary<string, string>();
        [NotMapped]
        public string Error => string.Join(Environment.NewLine, _validationErrorMessaged.Values.Where(m => !string.IsNullOrEmpty(m)));
    }
}
