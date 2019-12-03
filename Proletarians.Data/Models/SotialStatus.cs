
using System;

namespace Proletarians.Data.Models
{
    [Flags]
    public enum SotialStatus
    {
        Unknow,
        Proletarian = 1,
        Schooller = 2,
        Student = 4,
        Intellectual = 8,
        Teacher = 16,
        Retiree = 32,
        Services = 64,
        Bourgeois = 128,
        Unemployed = 256,
        Migrant = 512,
        Other = 1024
    }
}
