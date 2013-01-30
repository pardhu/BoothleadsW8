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
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using BoothLeads.ServiceClient.DataContracts;

namespace BoothLeads
{
    public partial class blEventExhibitors : PhoneApplicationPage
    {
        public blEventExhibitors()
        {
            InitializeComponent();
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Event Exhibitor";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadEventExhibitors(BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID, BoothLeadGlobalAccess.BLUserDetails.UserID);
            //DataReady(BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID, BoothLeadGlobalAccess.BLUserDetails.UserID);
            //LoadEventExhibitors();
        }

       


        private void LoadEventExhibitors(string eventID, string userid)
        {
            string serviceUri = string.Format(SalesForceServiceURL.SVC_EVENT_EXHIBITORS_URL, userid, eventID);
            WebClient wbClient1 = new WebClient();
            wbClient1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient1_DownloadStringCompleted);
            wbClient1.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient1.DownloadStringAsync(new Uri(serviceUri));
        }

        void wbClient1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<BLSFEXHIBITORS>));
            List<BLSFEXHIBITORS> evDetails = (List<BLSFEXHIBITORS>)obj.ReadObject(stream);

            website.Text = evDetails[0].Booth_Website;
            name.Text = evDetails[0].Booth_Name;
            description.Text = evDetails[0].Booth_Description;
            phonenumber.Text = evDetails[0].Booth_ContactPhoneNo;
            txtContactPersonName.Text = evDetails[0].Booth_ContactName;
            txtEmailAddress.Text = evDetails[0].Booth_ContactEmail;
            
        }
    }
}