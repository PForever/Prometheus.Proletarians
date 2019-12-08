
using AspectInjector.Broker;
using System;
using System.ComponentModel;
using System.Linq;

namespace Proletarians.Data.Models
{
    public class Period
    {
        public Guid Id { get; set; }
        [Notify]
        public DateTime Start { get; set; }
        [Notify]
        public DateTime Finish { get; set; }

        public override string ToString() => $"{Start:dd MMM yy} - {Finish:dd MMM yy}";
    }
}
