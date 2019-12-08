using AspectInjector.Broker;
using Microsoft.EntityFrameworkCore;
using Proletarians.Data;
using Proletarians.Data.Models;
using Prometheus.Proletarians.WpfCore.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Markup;

namespace Prometheus.Proletarians.WpfCore
{
    class ProfilesVo : BaseVm
    {
        public ObservableCollection<Profile> Profiles { get; set; }
        public ObservableCollection<Location> Locations { get; set; }
        public ObservableCollection<Period> Periods { get; set; }
        public ProfilesVo()
        {
            using var context = new PrometheusContext();
            Locations = new ObservableCollection<Location>(context.Locations);
            var t = new Period();
            Periods = new ObservableCollection<Period>(context.Periods);
            Profiles = new ObservableCollection<Profile>(context.Profiles.Include(p => p.AgeCategory).Include(p => p.Acquaintance.Location).Include(p => p.Acquaintance.Period).ToList());
        }
    }

    //public class InnerPeriod
    //{
    //    public Guid Id { get; set; }
    //    [InnerNotify(NotifyAlso = "Id")]
    //    public DateTime Start { get; set; }
    //    [InnerNotify(NotifyAlso = "Id")]
    //    public DateTime Finish { get; set; }

    //    public override string ToString() => $"{Start:dd MMM yy} - {Finish:dd MMM yy}";
    //}

    //[AttributeUsage(AttributeTargets.Property)]
    //[Injection(typeof(InnerNotifyAspect))]
    //public class InnerNotify : Attribute
    //{
    //    public string NotifyAlso { get; set; }
    //}


    //[Mixin(typeof(INotifyPropertyChanged))]
    //[Aspect(Scope.PerInstance)]
    //public class InnerNotifyAspect : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

    //    [Advice(Kind.After, Targets = Target.Public | Target.Setter)]
    //    public void AfterSetter(
    //        [Argument(Source.Instance)] object source,
    //        [Argument(Source.Name)] string propName,
    //        [Argument(Source.Injections)] Attribute[] injections
    //        )
    //    {
    //        PropertyChanged(source, new PropertyChangedEventArgs(propName));

    //        foreach (var i in injections.OfType<InnerNotify>().ToArray())
    //            PropertyChanged(source, new PropertyChangedEventArgs(i.NotifyAlso));
    //    }
    //}

    public class StringToPhoneConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string)) return Binding.DoNothing;

            if (!(value is PhoneNumber phone)) return string.Empty;
            return phone.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(PhoneNumber)) return Binding.DoNothing;
            if (!(value is string phone)) return string.Empty;

            var phoneNo = Regex.Replace(phone, @"[^\d]", "").AsSpan() is var res && res.Length > 0 && res[0] == '7' ? res.Slice(1) : res;// phone.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);

            switch (phoneNo.Length)
            {
                case 0:
                    return new PhoneNumber { ContryCode = 7 };
                case var l when l < 4:
                    return new PhoneNumber { ContryCode = 7, RegionCode = int.Parse(phoneNo) };
                case var l when l < 11:
                    return new PhoneNumber { ContryCode = 7, RegionCode = int.Parse(phoneNo.Slice(0, 3)), Number = int.Parse(phoneNo.Slice(3)) };
                //case 10:
                //    return new PhoneNumber { ContryCode = int.Parse(phoneNo.AsSpan().Slice(0, 1)), RegionCode = int.Parse(phoneNo.AsSpan().Slice(1, 3)), Number = int.Parse(phoneNo.AsSpan().Slice(4)) };
                default:
                    return Binding.DoNothing;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
