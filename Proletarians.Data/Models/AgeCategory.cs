
using System;

namespace Proletarians.Data.Models
{
    public class AgeCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
