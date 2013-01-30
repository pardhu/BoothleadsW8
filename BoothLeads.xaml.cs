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
using System.Runtime.Serialization.Json;
using System.Text;
using BoothLeads.ServiceClient.DataContracts;
using System.Windows.Media.Imaging;

namespace BoothLeads
{
    public partial class BoothLeads : PhoneApplicationPage
    {
        private List<LeadDetail> eventLeadsGlobal = null;
        private bool IsShowingGridView = false;
        public BoothLeads()
        {
            InitializeComponent();
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Leads";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);

            boothLead.VisibleSearchButton = System.Windows.Visibility.Visible;
            boothLead.VisibleUpdateProfileButton = System.Windows.Visibility.Visible;
            boothLead.VisibleEventsButton = System.Windows.Visibility.Visible;
            boothLead.VisibleAddLeadButton = System.Windows.Visibility.Visible;
            boothLead.VisibleBackButton = System.Windows.Visibility.Collapsed;

        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            //leadsGridView.Visibility = System.Windows.Visibility.Visible;
            //lstView.Visibility = System.Windows.Visibility.Collapsed;
            IsShowingGridView = true;
            LoadEvenLeads();

        }

        private void LoadEvenLeads()
        {
            WebClient wbClient = new WebClient();
            string leadURL = string.Format(SalesForceServiceURL.SVC_GETLEADS_URL, null, BoothLeadGlobalAccess.BLUserDetails.UserID);
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(leadURL), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<LeadDetail>));
            eventLeadsGlobal = (List<LeadDetail>)obj.ReadObject(stream);
            LoadListOrGridView(eventLeadsGlobal);
            ProxyLeadList.Leads = eventLeadsGlobal;
        }

        private void LoadListOrGridView(List<LeadDetail> evenLeads)
        {
            List<ListViewLeadItem> eventLeads = new List<ListViewLeadItem>();
            byte[] imageBlob = null;
            string imagePath = string.Empty;
            string strBase64string = string.Empty;
            if (IsShowingGridView == false)
            {
                BitmapImage bitmapImage = null;
                MemoryStream ms = null;
                string userid = string.Empty;
                ListViewLeadItem addItem = null;
                foreach (LeadDetail lead in evenLeads)
                {
                    bitmapImage = new BitmapImage();
                    if (lead.ImageBlob != null)
                    {
                        imageBlob = Convert.FromBase64String(lead.ImageBlob);
                        ms = new MemoryStream(Convert.FromBase64String(lead.ImageBlob));
                        bitmapImage.SetSource(ms);
                    }
                    else
                    {
                        bitmapImage.UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative);
                    }

                    addItem = new ListViewLeadItem();
                    addItem.CompanyName = lead.Company;
                    addItem.LeadName = lead.Firstname + " " + lead.Lastname;
                    addItem.ImageSource = bitmapImage;
                    addItem.Barcodeid = lead.Barcodeid;
                    if (string.IsNullOrEmpty(lead.leadRating)) 
                        lead.leadRating = "0";
                    switch (Convert.ToInt32(lead.leadRating))
                    {
                        case 0:
                            break;
                        case 1:
                            addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            break;
                        case 2:
                            addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            break;
                        case 3:
                            addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            break;
                        case 4:
                            addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating4 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            break;
                        case 5:
                            addItem.Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating3 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating4 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            addItem.Rating5 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) };
                            break;
                    }
                    eventLeads.Add(addItem);
                    //eventLeads.Add(new ListViewLeadItem { CompanyName = lead.Company, LeadName = lead.Firstname + " " + lead.Lastname, ImageSource = bitmapImage, Rating = lead.leadRating, UserId = userid, EventId = lead.EventId, Rating1 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) }, Rating2 = new BitmapImage { UriSource = new Uri("/Images/RatingStart.png", UriKind.Relative) } });
                }

                lstView.Visibility = System.Windows.Visibility.Visible;
                leadsGridView.Visibility = System.Windows.Visibility.Collapsed;
                lstView.ItemsSource = eventLeads;
            }
            else
            {
                BitmapImage bitmapImage = null;
                MemoryStream ms = null;
                string userid = string.Empty;
                foreach (LeadDetail lead in evenLeads)
                {
                    bitmapImage = new BitmapImage();
                    if (lead.ImageBlob != null)
                    {
                        imageBlob = Convert.FromBase64String(lead.ImageBlob);
                        ms = new MemoryStream(Convert.FromBase64String(lead.ImageBlob));
                        bitmapImage.SetSource(ms);
                    }
                    else
                    {

                        bitmapImage.UriSource = new Uri("/Images/defaultUser.png", UriKind.Relative);
                    }

                    eventLeads.Add(new ListViewLeadItem { ImageSource = bitmapImage, Barcodeid = lead.Barcodeid});
                }
                lstView.Visibility = System.Windows.Visibility.Collapsed;
                leadsGridView.Visibility = System.Windows.Visibility.Visible;
                leadsGridView.ItemsSource = eventLeads;
            }
        }



        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsComp = new List<LeadDetail>();
            IEnumerable<LeadDetail> companylist = eventLeadsGlobal.OrderBy(comp => comp.Company);
            foreach (LeadDetail company in companylist)
            {
                if (string.IsNullOrEmpty(company.Company) == false)
                    leadsComp.Add(company);
            }

            //btnCompany.Background = new SolidColorBrush("#73172C"); 
            btnCompany.Background = new SolidColorBrush(Colors.Purple);
            btnRating.Background = new SolidColorBrush(Colors.Gray);
            btnName.Background = new SolidColorBrush(Colors.Gray);
            btnDate.Background = new SolidColorBrush(Colors.Gray);

            LoadListOrGridView(leadsComp);
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsName = new List<LeadDetail>();
            IEnumerable<LeadDetail> nameList = eventLeadsGlobal.OrderBy(comp => comp.Firstname);
            foreach (LeadDetail fname in nameList)
            {
                if (string.IsNullOrEmpty(fname.Firstname) == false)
                    leadsName.Add(fname);
            }

            LoadListOrGridView(leadsName);
            btnCompany.Background = new SolidColorBrush(Colors.Gray);
            btnRating.Background = new SolidColorBrush(Colors.Gray);
            btnName.Background = new SolidColorBrush(Colors.Purple);
            btnDate.Background = new SolidColorBrush(Colors.Gray);
        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsDate = new List<LeadDetail>();
            IEnumerable<LeadDetail> companylist = eventLeadsGlobal.OrderBy(nextfollow => nextfollow.NextFollowUpdate);
            foreach (LeadDetail dates in eventLeadsGlobal)
            {
                if (string.IsNullOrEmpty(dates.NextFollowUpdate) == false)
                    leadsDate.Add(dates);
            }
            btnCompany.Background = new SolidColorBrush(Colors.Gray);
            btnRating.Background = new SolidColorBrush(Colors.Gray);
            btnName.Background = new SolidColorBrush(Colors.Gray);
            btnDate.Background = new SolidColorBrush(Colors.Purple);
            LoadListOrGridView(leadsDate);
        }

        private void btnRating_Click(object sender, RoutedEventArgs e)
        {
            List<LeadDetail> leadsRating = new List<LeadDetail>();
            IEnumerable<LeadDetail> ratingsort = eventLeadsGlobal.OrderByDescending(rat => rat.leadRating);
            foreach (LeadDetail rating in ratingsort)
            {
                if (string.IsNullOrEmpty(rating.leadRating) == false)
                    leadsRating.Add(rating);
            }

            LoadListOrGridView(leadsRating);
            btnCompany.Background = new SolidColorBrush(Colors.Gray);
            btnRating.Background = new SolidColorBrush(Colors.Purple);
            btnName.Background = new SolidColorBrush(Colors.Gray);
            btnDate.Background = new SolidColorBrush(Colors.Gray);
        }

        private void btnGridView_Click(object sender, RoutedEventArgs e)
        {
            btnCompany.Background = new SolidColorBrush(Colors.Gray);
            btnRating.Background = new SolidColorBrush(Colors.Gray);
            btnName.Background = new SolidColorBrush(Colors.Gray);
            btnDate.Background = new SolidColorBrush(Colors.Gray);

            IsShowingGridView = true;
            LoadListOrGridView(eventLeadsGlobal);

        }


        private void btnListView_Click(object sender, RoutedEventArgs e)
        {
            btnCompany.Background = new SolidColorBrush(Colors.Gray);
            btnRating.Background = new SolidColorBrush(Colors.Gray);
            btnName.Background = new SolidColorBrush(Colors.Gray);
            btnDate.Background = new SolidColorBrush(Colors.Gray);

            IsShowingGridView = false;

            LoadListOrGridView(eventLeadsGlobal);
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstView.SelectedIndex == -1)
                return;

             ListViewLeadItem selectedItem = (ListViewLeadItem)lstView.SelectedValue;
             if (selectedItem != null)
             {
                 NavigationService.Navigate(new Uri("/blLeadDetails.xaml?selecteduser=" + selectedItem.Barcodeid, UriKind.Relative));
             }

            lstView.SelectedIndex = -1;
        }

       
        private void leadsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (leadsGridView.SelectedIndex == -1)
                return;

            ListViewLeadItem selectedItem = (ListViewLeadItem)leadsGridView.SelectedValue;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new Uri("/blLeadDetails.xaml?selecteduser=" + selectedItem.Barcodeid, UriKind.Relative));
            }

            leadsGridView.SelectedIndex = -1;
        }


    }
}