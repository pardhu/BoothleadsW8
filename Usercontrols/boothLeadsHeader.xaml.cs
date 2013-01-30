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
using BoothLeads.BoothLeadsEntity;
using BoothLeads.BoothLeadDataHelper;
using System.Windows.Controls.Primitives;


namespace BoothLeads
{
    public partial class boothLeadsHeader : UserControl
    {
        public boothLeadsHeader()
        {
            InitializeComponent();

        }

        public string HeaderText { get; set; }
        public string PreviousPage { get; set; }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            txtHeaderText.Text = HeaderText;
            
        }

        public Visibility VisibleSearchButton
        {
            set
            {
                btnSearchLead.Visibility = value;
            }
        }

        public Visibility VisibleEventsButton
        {
            set
            {
                btnEvents.Visibility = value;
            }
        }

        public Visibility VisibleUpdateProfileButton
        {

            set
            {
                btnUpdateProfile.Visibility = value;
            }
        }


        public string BackButtonImage { get; set; }
        
        public Visibility VisibleBackButton
        {

            set
            {
                btnBack.Visibility = value;
            }
        }
        public Visibility VisibleMoreButton
        {

            set
            {
                btnMore.Visibility = value;
            }
        }

        public Visibility VisibleAddLeadButton
        {
            set
            {
                btnAddLead.Visibility = value;
            }
        }

        public Visibility VisibleLogoutButtom
        {

            set
            {
                btnLogout.Visibility = value;
            }
        }
        private void OnBackbuttonClick(object sender, RoutedEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/" + PreviousPage + ".xaml", UriKind.Relative));
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/UserProfile.xaml", UriKind.Relative));
        }
        private void btnSearchLead_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OnMoreButtonclick(object sender, RoutedEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/boothleadsMore.xaml", UriKind.Relative));
        }

        private void evenDetails_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/blEvents.xaml", UriKind.Relative));
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            DeleteDataFromDatabase();
        }

        private void DeleteDataFromDatabase()
        {
            BLHAttendeeDetails attendee = new BLHAttendeeDetails();
            attendee.DeleteAttendeeDetails();
            BLHUserInfo userinfo = new BLHUserInfo();
            userinfo.DeleteUserInfo();
            BLHLeadDetails leadDetail = new BLHLeadDetails();
            leadDetail.DeleteLeadDetails();
            BLHEventSchedule evntsch = new BLHEventSchedule();
            evntsch.DeleteEventSchedule();
            BLHEventDeail evntDetail = new BLHEventDeail();
            evntDetail.DeleteEventdetails();
            BLHBoothDetails boothleads = new BLHBoothDetails();
            boothleads.DeleteBoothDetails();
            BLHUserInfo usrinfo = new BLHUserInfo();
            usrinfo.DatabaseVaccum();
            BoothLeadGlobalAccess.Access_Token = null;
            BoothLeadGlobalAccess.BLUserDetails = null;
            BoothLeadGlobalAccess.SfUserId = null;
            (App.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void btnAddLead_Click(object sender, RoutedEventArgs e)
        {

            Popup popup; 
            popup = new Popup();

            // Set the Child property of Popup to an instance of MyControl.
            popup.Child = new blMenuUserControl();

            // Set where the popup will show up on the screen.
            
            popup.VerticalOffset = 86;
            popup.HorizontalOffset = 2;

            // Open the popup.
            popup.IsOpen = true; 

        }

    }
}
