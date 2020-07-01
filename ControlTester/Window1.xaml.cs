using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTester
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //private void LostCapture(object sender, RoutedEventArgs e)
        //{
        //    _block.Text = "Respect to Window ";
        //}
        
        //private void OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    var point = e.GetPosition((IInputElement) sender);
        //    _block.Text = $"({point.X:0.00}; {point.Y:0.00})";
        //}

        //private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Mouse.Capture(_rect);
        //    AddHandler(Mouse.LostMouseCaptureEvent, new RoutedEventHandler(LostCapture));
        //}

        //private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Mouse.Capture(null);
        //}
    }
}
