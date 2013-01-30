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
using BoothLeads.ServiceClient.DataContracts;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace BoothLeads
{
    public partial class BlVerifyLead : PhoneApplicationPage
    {
        public BlVerifyLead()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Veryfy Lead";
            boothLead.PreviousPage = "mainpage";
            TitlePanel.Children.Add(boothLead);
            VerifyLeads(BoothLeadGlobalAccess.BLUserDetails.UserID, BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID);
        }

        private void VerifyLeads(string userid, string eventId)
        {
            WebClient wbClient = new WebClient();
            wbClient.UploadStringCompleted += new UploadStringCompletedEventHandler(wbClient_UploadStringCompleted);
            string syncLeadsUrl = string.Format(SalesForceServiceURL.SVC_VERIFYLEADS_URL, eventId, userid, "a06O000000HmtrGIAR");
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.UploadStringAsync(new Uri(syncLeadsUrl), "POST", string.Empty);
        }

        void wbClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(UsersDetails));
            UsersDetails slResponse = (UsersDetails)obj.ReadObject(stream);
        }

        
    
        
    }
}