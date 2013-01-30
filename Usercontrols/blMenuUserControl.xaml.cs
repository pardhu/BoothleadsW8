using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BoothLeads
{
    public partial class blMenuUserControl : UserControl
    {
        public blMenuUserControl()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blQRCodeScanner.xaml", UriKind.Relative));

        }

        private void grdMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
        }

        private void grdMenu_MouseMove(object sender, MouseEventArgs e)
        {
            this.Visibility = Visibility.Collapsed; 
        }
    }
}
