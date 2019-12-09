
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Proletarians.Data.Models
{
    public class Profile : IDataErrorInfo
    {
        private Contacts _contacts;

        public string this[string columnName] => columnName switch
        {
            nameof(Contacts) => Contacts?.Error ?? "Контактный адресс не указан",
            _ => string.Empty
        };

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        [Notify]
        public Contacts Contacts
        {
            get => _contacts; set
            {
                _contacts = value;
                Validate();
            }
        }
        public AgeCategory AgeCategory { get; set; }
        public string AdditionalInformations { get; set; }
        public Acquaintance Acquaintance { get; set; }
        public SotialStatus SotialStatus { get; set; }
        public Relation Relation { get; set; }
        public OrganizationStatus OrganizationStatus { get; set; }
        public ParticipantStatus ParticipantStatus { get; set; }
        private void Validate([CallerMemberName] string propertyName = "") => _validationErrorMessaged.AddOrUpdate(propertyName, k => this[k], (k, _) => this[k]);
        private ConcurrentDictionary<string, string> _validationErrorMessaged = new ConcurrentDictionary<string, string>();
        [NotMapped]
        public string Error => string.Join(Environment.NewLine, _validationErrorMessaged.Values.Where(m => !string.IsNullOrEmpty(m)));
    }
}
