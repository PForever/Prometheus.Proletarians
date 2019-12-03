using Proletarians.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Proletarians
{
    public class InvitationProfileView
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public PhoneNumber Phone { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set; }
        public Guid AgeCategoryId { get; set; }
        public string AdditionalInformations { get; set; }
        public Acquaintance Acquaintance { get; set; }
        public SotialStatus SotialStatus { get; set; }
        public Relation Relation { get; set; }
        public OrganizationStatus OrganizationStatus { get; set; }
        public ParticipantStatus ParticipantStatus { get; set; }
    }
}
