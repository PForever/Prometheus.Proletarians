﻿
using System;

namespace Proletarians.Data.Models
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public Contacts Contacts { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public string AdditionalInformations { get; set; }
        public Acquaintance Acquaintance { get; set; }
        public SotialStatus SotialStatus { get; set; }
        public Relation Relation { get; set; }
        public OrganizationStatus OrganizationStatus { get; set; }
        public ParticipantStatus ParticipantStatus { get; set; }
    }
}