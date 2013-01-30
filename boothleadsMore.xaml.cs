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
    public partial class boothleadsMore : PhoneApplicationPage
    {
        public boothleadsMore()
        {
            InitializeComponent();
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "More";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);

            boothLead.VisibleSearchButton = System.Windows.Visibility.Visible;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Visible;
        }

        private void btnEventshome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/EventDetails.xaml"), UriKind.Relative));
        }

        private void btnEventschedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/blEventSchedule.xaml"), UriKind.Relative));
        }

        private void btnEventExhibor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/blEventExhibitors.xaml"), UriKind.Relative));
        }

        private void btncheckoutofEvents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
        }
    }
}