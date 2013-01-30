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
using BoothLeads.ServiceClient;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using BoothLeads.ServiceClient.DataContracts;
using System.Windows.Media.Imaging;

namespace BoothLeads
{
    public partial class UserProfile : PhoneApplicationPage
    {
        public UserProfile()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = BoothLeadGlobalAccess.BLUserDetails.FirstName + " " + BoothLeadGlobalAccess.BLUserDetails.LastName;
            boothLead.PreviousPage = "BoothLeads";
            TitlePanel.Children.Add(boothLead);
            LoadLeadDetails();
            boothLead.VisibleBackButton = System.Windows.Visibility.Visible;
            boothLead.VisibleEventsButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleLogoutButtom = System.Windows.Visibility.Visible;
            boothLead.VisibleMoreButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleSearchButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Collapsed;

            grdUserProfile.Visibility = System.Windows.Visibility.Visible;
            grdAbout.Visibility = System.Windows.Visibility.Collapsed;
            grdSnsSettings.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void LoadLeadDetails()
        {
            UsersDetails userDetail = BoothLeadGlobalAccess.BLUserDetails;
            txtFirstName.Text = userDetail.FirstName;
            txtLastName.Text = userDetail.LastName;
            txtCity.Text = userDetail.City;
            txtCompany.Text = userDetail.Company;
            txtEmail.Text = userDetail.Email;
            txtPhone.Text = userDetail.PhoneNo;
            txtState.Text = userDetail.State;
            if (string.IsNullOrEmpty(userDetail.ImageUrl))
            {
                userImage.Source = new BitmapImage { UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative) };
                pageHeaderImage.Source = new BitmapImage { UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative) }; 
            }
            else
            {
                userImage.Source = new BitmapImage { UriSource = new Uri(userDetail.ImageUrl, UriKind.Relative) };
                pageHeaderImage.Source = new BitmapImage { UriSource = new Uri(userDetail.ImageUrl, UriKind.Relative) };
            }
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string firstName = BoothLeadGlobalAccess.BLUserDetails.FirstName;
            string lastName = BoothLeadGlobalAccess.BLUserDetails.LastName;
            string city = BoothLeadGlobalAccess.BLUserDetails.City;
            string phone = BoothLeadGlobalAccess.BLUserDetails.PhoneNo;
            string state = BoothLeadGlobalAccess.BLUserDetails.State;
            string company = BoothLeadGlobalAccess.BLUserDetails.Company;

            WebClient wbClient = new WebClient();
            string updateURL = string.Format(SalesForceServiceURL.SVC_SAVE_USER_PROFILE_URL, BoothLeadGlobalAccess.BLUserDetails.UserID, firstName, lastName, company, city, state, phone);
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(updateURL), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(ServiceResponse));
            ServiceResponse slResponse = (ServiceResponse)obj.ReadObject(stream);
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/blQRCodeScanner.xaml"), UriKind.Relative));
        }

        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            btnUserProfile.Background = new SolidColorBrush(Colors.DarkGray);
            btnAbout.Background = new SolidColorBrush(Colors.Transparent);
            btnSNSSettings.Background = new SolidColorBrush(Colors.Transparent);
            grdUserProfile.Visibility = System.Windows.Visibility.Visible;
            grdAbout.Visibility = System.Windows.Visibility.Collapsed;
            grdSnsSettings.Visibility = System.Windows.Visibility.Collapsed;
            txtFirstName.Visibility = System.Windows.Visibility.Visible;
            txtLastName.Visibility = System.Windows.Visibility.Visible;
            userImage.Visibility = System.Windows.Visibility.Visible;
            

        }

        private void btnSNSSettings_Click(object sender, RoutedEventArgs e)
        {
            btnUserProfile.Background = new SolidColorBrush(Colors.Transparent);
            btnAbout.Background = new SolidColorBrush(Colors.Transparent);
            btnSNSSettings.Background = new SolidColorBrush(Colors.DarkGray);
            grdUserProfile.Visibility = System.Windows.Visibility.Collapsed;
            grdAbout.Visibility = System.Windows.Visibility.Collapsed;
            grdSnsSettings.Visibility = System.Windows.Visibility.Visible;
            txtFirstName.Visibility = System.Windows.Visibility.Collapsed;
            txtLastName.Visibility = System.Windows.Visibility.Collapsed;
            userImage.Visibility = System.Windows.Visibility.Collapsed;
            
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            btnUserProfile.Background = new SolidColorBrush(Colors.Transparent);
            btnAbout.Background = new SolidColorBrush(Colors.DarkGray);
            btnSNSSettings.Background = new SolidColorBrush(Colors.Transparent);
            grdUserProfile.Visibility = System.Windows.Visibility.Collapsed;
            grdAbout.Visibility = System.Windows.Visibility.Visible;
            grdSnsSettings.Visibility = System.Windows.Visibility.Collapsed;
            txtFirstName.Visibility = System.Windows.Visibility.Collapsed;
            txtLastName.Visibility = System.Windows.Visibility.Collapsed;
            userImage.Visibility = System.Windows.Visibility.Collapsed;
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/BoothLeads.xaml"), UriKind.Relative));
        }
    }
}