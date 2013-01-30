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
using BoothLeads.ServiceClient.DataContracts;
using System.Windows.Media.Imaging;

namespace BoothLeads
{
    public partial class blEvents : PhoneApplicationPage
    {
        public blEvents()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Events";
            boothLead.PreviousPage = "BoothLeads";
            TitlePanel.Children.Add(boothLead);

            boothLead.VisibleSearchButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Visible;
            boothLead.VisibleMoreButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleBackButton = System.Windows.Visibility.Visible;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleEventsButton = System.Windows.Visibility.Collapsed;

            LoadEvents();
        }

        private void LoadEvents()
        {
            BitmapImage bitmapImage = null;
            List<ListViewEventItem> eventlist = new List<ListViewEventItem>();
            foreach (BoothLeadsEntity.BldbEventdetails evDetail in BoothLeadGlobalAccess.BLUserDetails.Edetails)
            {
                //if (string.IsNullOrEmpty(evDetail.EventLogoImageURL) == false)
                //{
                //    evDetail.EventLogoImageURL = evDetail.EventLogoImageURL.Substring(0, evDetail.EventLogoImageURL.IndexOf("&id"));
                //    bitmapImage = new BitmapImage(new Uri(evDetail.EventLogoImageURL));
                //}
                //else
                //{
                //    bitmapImage.UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative);
                //}
                bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative);
                eventlist.Add(new ListViewEventItem { EventId = evDetail.Event_ID, ImageSource = bitmapImage });
            }
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for android", Event_Location = "Hyderabad", Event_Name = "Android Session", Event_ID = "1" });
            //eventlist.Add(new EventDetail { EventLogoImageURL  = "/Images/defaultUser.png", Message = "This is an event for C#", Event_Location = "Hyderabad", Event_Name = "Ms.NET Session", Event_ID = "2" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for VB.NET", Event_Location = "Hyderabad", Event_Name = "VB.NET Session", Event_ID = "3" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for Eclipse", Event_Location = "Hyderabad", Event_Name = "Eclipse Session", Event_ID = "4" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for Java", Event_Location = "Hyderabad", Event_Name = "Java Session", Event_ID = "5" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for REST", Event_Location = "Hyderabad", Event_Name = "REST Session", Event_ID = "6" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for WCF", Event_Location = "Hyderabad", Event_Name = "WCF Session", Event_ID = "7" });
            //eventlist.Add(new EventDetail { EventLogoImageURL = "/Images/defaultUser.png", Message = "This is an event for Google API", Event_Location = "Hyderabad", Event_Name = "Google API Session", Event_ID = "8" });

            blEventsView.ItemsSource = eventlist;
        }

        private void blEventsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (blEventsView.SelectedIndex == -1)
                return;

            ListViewEventItem selectedItem = (ListViewEventItem)blEventsView.SelectedValue;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new Uri("/EventDetails.xaml?eventID=" + selectedItem.EventId, UriKind.Relative));
            }

            blEventsView.SelectedIndex = -1;
        }
    }
}