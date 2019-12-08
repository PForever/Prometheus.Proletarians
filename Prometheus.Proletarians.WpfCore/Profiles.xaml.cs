using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prometheus.Proletarians.WpfCore
{
    /// <summary>
    /// Interaction logic for Profiles.xaml
    /// </summary>
    public partial class Profiles : Page
    {
        public Profiles()
        {
            InitializeComponent();
        }
        private void OnPreviewPhoneChanged(object sender, TextCompositionEventArgs e)
        {
            if(e.Text is var phone && int.TryParse(phone, out int _))
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private static string ToMask(string phone)
        {
            switch (phone.Length)
            {
                case 7:
                    return Regex.Replace(phone, @"(\d{3})(\d{4})", "$1-$2");
                case 10:
                    return Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
                case 11:
                    return Regex.Replace(phone, @"(\d{1})(\d{3})(\d{3})(\d{4})", "$1-$2-$3-$4");
                default:
                    return phone;
            }
        }
    }
}
