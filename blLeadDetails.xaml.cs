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
using System.IO;
using BoothLeads.ServiceClient;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Windows.Controls.Primitives;

namespace BoothLeads
{
    public partial class blLeadDetails : PhoneApplicationPage
    {
        private LeadDetail leadValue = null;
        public blLeadDetails()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.VisibleBackButton = System.Windows.Visibility.Visible;
            boothLead.VisibleEventsButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleMoreButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Collapsed;
            boothLead.VisibleSearchButton = System.Windows.Visibility.Collapsed;

            boothLead.HeaderText = "Boothleads";
            boothLead.PreviousPage = "BoothLeads";
            TitlePanel.Children.Add(boothLead);
            LoadLeadDetails();
        }

        private void LoadLeadDetails()
        {
            string parameterValue = NavigationContext.QueryString["selecteduser"];
            if (ProxyLeadList.Leads != null && string.IsNullOrEmpty(parameterValue) == false)
            {
                foreach (LeadDetail item in ProxyLeadList.Leads)
                {
                    if (item.Barcodeid == parameterValue)
                    {
                        leadValue = item;
                        break;
                    }
                }

                txtFirstName.Text = string.IsNullOrEmpty(leadValue.Firstname) == false ? leadValue.Firstname : "First Name";
                txtLastName.Text = string.IsNullOrEmpty(leadValue.Lastname) == false ? leadValue.Lastname : "Last Name";
                txtNotes.Text = string.IsNullOrEmpty(leadValue.Notes) == false ? leadValue.Notes : "Notes";
                txtPhoneNumber.Text = string.IsNullOrEmpty(leadValue.Phone) == false ? leadValue.Phone : "Phone";
                txtEmailAddress.Text = string.IsNullOrEmpty(leadValue.Email) == false ? leadValue.Email : "Email";
                txtCity.Text = string.IsNullOrEmpty(leadValue.City) == false ? leadValue.City : "City";
                txtState.Text = string.IsNullOrEmpty(leadValue.state) == false ? leadValue.state : "State";
                txtTitle.Text = string.IsNullOrEmpty(leadValue.Designation) == false ? leadValue.Designation : "Title";
                txtCompany.Text = string.IsNullOrEmpty(leadValue.Company) == false ? leadValue.Company : "Company";

                if (leadValue.ImageBlob == null)
                    usrImage.Source = new BitmapImage { UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative) };
                else
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    byte[] imageBlob = Convert.FromBase64String(leadValue.ImageBlob);
                    MemoryStream ms = new MemoryStream(Convert.FromBase64String(leadValue.ImageBlob));
                    bitmapImage.SetSource(ms);
                    usrImage.Source = bitmapImage;
                }

                switch (Convert.ToInt32(leadValue.leadRating))
                {
                    case 0:
                        break;
                    case 1:
                        blRating1.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 2:
                        blRating1.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating2.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 3:
                        blRating1.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating2.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating3.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 4:
                        blRating1.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating2.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating3.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating4.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                    case 5:
                        blRating1.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating2.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating3.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating4.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        blRating5.Source = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                        break;
                }

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BoothLeads.xaml", UriKind.Relative));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WebClient wbClient = new WebClient();
            string updateURL = string.Format(SalesForceServiceURL.SVC_SAVE_USER_PROFILE_URL, BoothLeadGlobalAccess.BLUserDetails.UserID, txtFirstName.Text, txtLastName.Text, txtCompany.Text, txtCity.Text, txtState.Text, txtPhoneNumber.Text);
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

        private void btnSurveyTypes_Click(object sender, RoutedEventArgs e)
        {
            if (leadValue != null)
            {
                MessageBox.Show(leadValue.SurveyQuestion1 + "\n" + leadValue.SurveyQuestion2 + "\n" + leadValue.SurveyQuestion3 + "\n" + leadValue.SurveyQuestion4);
            }
        }
    }
}