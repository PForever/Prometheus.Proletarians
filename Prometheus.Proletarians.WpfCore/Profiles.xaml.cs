using Proletarians.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        //private void OnPreviewPhoneChanged(object sender, TextCompositionEventArgs e)
        //{
        //    if(e.Text is var phone && int.TryParse(phone, out int _) && e.Source is TextBox tb && tb.Text.Length is var len && len <= 17)
        //    {
        //        tb.CaretIndex = len;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void OnPhoneChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void OnAddress(object sender, RoutedEventArgs e)
        {
            switch (sender)
            {
                case DataGridRow row when row.Item is Profile profile:
                    //todo copy
                    //var windows = new Address();
                    //if (profile.Contacts.Address is { } address) windows.DataContext = address;
                    //else profile.Contacts.Address = (global::Proletarians.Data.Models.Address)windows.DataContext;
                    //windows.Owner = Application.Current.MainWindow;//Window.GetWindow(this);
                    //windows.ShowDialog();
                    break;
                case DataGridCell cell:
                    //cell.IsEditing = true;
                    break;
                case DataGrid dg:
                    //dg.BeginEdit(e);
                    break;
                case Button bt when bt.Content is StackPanel sp && sp.Children.Cast<object>().FirstOrDefault(ch => ch is Popup) is Popup p:
                    if (p.IsOpen) e.Handled = true;
                    p.IsOpen = !p.IsOpen;
                    break;
            }
        }

        private void OnCellLeftClick(object sender, MouseButtonEventArgs e)
        {
            //в тунельном эдит, в пузырьковом действие
            if (sender is DataGridCell cell)
            {
                if (!cell.IsEditing)
                {
                    if (!cell.IsFocused) cell.Focus();
                    _dg.BeginEdit(e);
                }
            }

            //if (sender is DataGridRow row)
            //{
            //}
        }
    }
}