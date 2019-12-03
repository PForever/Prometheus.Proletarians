using Microsoft.EntityFrameworkCore;
using System;

namespace Proletarians.Data.Models
{
    [Owned]
    public class Interval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Contains(DateTime time) => time >= From && time <= To;
    }
}
