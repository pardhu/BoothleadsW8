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
using System.IO;
using System.Runtime.Serialization.Json;
using BoothLeads.BoothLeadsEntity;
using System.Windows.Media.Imaging;
using System.Text;

namespace BoothLeads
{
    public partial class EventDetails : PhoneApplicationPage
    {
        public EventDetails()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Event Details";
            boothLead.PreviousPage = "blEvents";
            TitlePanel.Children.Add(boothLead);
            LoadEventDetail();
            boothLead.VisibleAddLeadButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleBackButton = System.Windows.Visibility.Visible;
            boothLead.VisibleEventsButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleLogoutButtom = System.Windows.Visibility.Collapsed;
            boothLead.VisibleMoreButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleSearchButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Collapsed;
        }



        //private void GetEventdetails(string userid, string eventId)
        //{
        //    WebClient wbClient = new WebClient();
        //    wbClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient_DownloadStringCompleted);
        //    string eventdetailURL = string.Format(SalesForceServiceURL.SVC_EVENTDETAILS_URL, userid, eventId);
        //    wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
        //    wbClient.DownloadStringAsync(new Uri(eventdetailURL));
        //}

        //void wbClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //{
        //    Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
        //    DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(EventDetail));
        //    EventDetail evDetails = (EventDetail)obj.ReadObject(stream);
        //    LoadEventDetail(evDetails);
        //}

        private BldbEventdetails GetSelectedEvenDetail()
        {
            string strEventId = Convert.ToString(NavigationContext.QueryString["eventID"]);
            BldbEventdetails eventDetail = null;
            foreach (BldbEventdetails evDetail in BoothLeadGlobalAccess.BLUserDetails.Edetails)
            {
                if (evDetail.Event_ID == strEventId)
                {
                    eventDetail = evDetail;
                    //if (string.IsNullOrEmpty(eventDetail.EventLogoImageURL) == false)
                        //eventDetail.EventLogoImageURL = evDetail.EventLogoImageURL.Substring(0, evDetail.EventLogoImageURL.IndexOf("&id"));
                    //break;
                }
            }
            return eventDetail;
        }

        private void LoadEventDetail()
        {
            BldbEventdetails eventDetail = GetSelectedEvenDetail();
            string strAddress = string.Empty;
            if (string.IsNullOrEmpty(eventDetail.HostingAddr1) == false)
                strAddress = eventDetail.HostingAddr1;

            if (string.IsNullOrEmpty(eventDetail.HostingAddr2) == false)
                strAddress += "+" + eventDetail.HostingAddr2;

            if (string.IsNullOrEmpty(eventDetail.HostingCity) == false)
                strAddress += "+" + eventDetail.HostingCity;

            string gmapUrl = "http://maps.googleapis.com/maps/api/geocode/json?sensor=true&address=" + strAddress;
            WebClient wbClient = new WebClient();
            wbClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient_DownloadStringCompleted);
            wbClient.DownloadStringAsync(new Uri(gmapUrl));

        }

        void wbClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(GeoResponse));
            GeoResponse result = (GeoResponse)obj.ReadObject(stream);
            BldbEventdetails eventDetail = GetSelectedEvenDetail();

            eventImage.Source = new BitmapImage(new Uri(eventDetail.EventLogoImageURL));
            txtBleventName.Text = eventDetail.Event_Name;
            txtblkDescription.Text = eventDetail.Event_Description;

            System.Device.Location.GeoCoordinate cordinator = new System.Device.Location.GeoCoordinate();
            cordinator.Latitude = result.results[0].geometry.location.lat;
            cordinator.Longitude = result.results[0].geometry.location.lng;
            bngMapname.LocationToViewportPoint(cordinator);


        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/blEventSchedule.xaml"), UriKind.Relative));
        }
    }
}