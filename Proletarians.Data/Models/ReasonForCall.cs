
using Microsoft.EntityFrameworkCore;
using System;

namespace Proletarians.Data.Models
{
    [Owned]
    public class ReasonForCall
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
    }
}
