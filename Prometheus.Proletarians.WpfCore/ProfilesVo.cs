﻿using AspectInjector.Broker;
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

    public class StringToPhoneConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string)) return Binding.DoNothing;

            if (!(value is PhoneNumber phone)) return string.Empty;
            _instance = value as PhoneNumber;
            return phone.ToString();
        }
        //private object[] _result = new object[2];
        private PhoneNumber _instance;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(PhoneNumber) || !(value is string phone))
            {
                return SetResult(Binding.DoNothing);
            }
            var phoneNo = Regex.Replace(phone, @"[^\d]", "").AsSpan() is var res && res.Length > 0 && res[0] == '7' ? res.Slice(1) : res;// phone.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);
            var result = _instance ?? new PhoneNumber(0, 0, 0);
            switch (phoneNo.Length)
            {
                case 0:
                    return SetResult(result, p => p.ContryCode = 7);
                case var l when l < 4:
                {
                    int regionCode = int.Parse(phoneNo);
                    return SetResult(result, p => p.ContryCode = 7, p => p.RegionCode = regionCode);
                }
                //case var l when l < 11:
                default:
                {
                    int regionCode = int.Parse(phoneNo.Slice(0, 3));
                    int number = int.Parse(phoneNo.Slice(3));
                    return SetResult(result, p => p.ContryCode = 7, p => p.RegionCode = regionCode, p => p.Number = number);
                }
                //default:
                //    return Binding.DoNothing;
            }
        }

        private object SetResult<T>(T value, params Action<T>[] actions)
        {
            foreach (var action in actions) action(value);
            //_result[0] = value;
            //_result[1] = value;
            return value;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
