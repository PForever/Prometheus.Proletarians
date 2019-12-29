using Proletarians.Data.Models;
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
            if(e.Text is var phone && int.TryParse(phone, out int _) && e.Source is TextBox tb && tb.Text.Length is var len && len <= 17)
            {
                tb.CaretIndex = len;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void OnAddNewProfile(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new Profile { Contacts = new Contacts { } };
        }

        private void OnPhoneChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}