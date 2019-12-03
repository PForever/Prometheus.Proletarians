using System;

namespace Proletarians.Data.Models
{
    public class Assign
    {
        public Manager Manager { get; set; }
        public Guid ManagerId { get; set; }
        public ResponsrbleField ResponsrbleField { get; set; }
        public Guid ResponsrbleFieldId { get; set; }
    }
}
