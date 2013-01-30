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
using BoothLeads.BoothLeadsEntity;
using BoothLeads.ServiceClient.DataContracts;
using System.Reflection;

namespace BoothLeads
{
    public partial class blEventSchedule : PhoneApplicationPage
    {
        public blEventSchedule()
        {
            InitializeComponent();
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            boothLeadsHeader boothLead = new boothLeadsHeader();
            boothLead.HeaderText = "Event Schedule";
            TitlePanel.Children.Add(boothLead);
            LoadEventSchedule(BoothLeadGlobalAccess.BLUserDetails.Edetails[0].Event_ID);
            
        }


        private void LoadEventSchedule(string evenId)
        {
            string serviceUri = string.Format(SalesForceServiceURL.SVC_EVENTSCHEDULE_URL, evenId);
            WebClient wbClient = new WebClient();
            wbClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wbClient_DownloadStringCompleted);
            wbClient.Headers["Authorization"] = BoothLeadGlobalAccess.Access_Token;
            wbClient.DownloadStringAsync(new Uri(serviceUri));
        }

        

       
        
        void wbClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            SFEventSchedule evenSchedule = new SFEventSchedule();
            string result = e.Result;
            result = result.Replace("\"", "");
            result = result.Replace("}]", "");
            result = result.Replace("[{", "");
            string[] listResult = result.Split(',');
            string[] values = null;

            PropertyInfo[] propertyList = evenSchedule.GetType().GetProperties();
            foreach (PropertyInfo propinfo in propertyList)
            {
                foreach (string item in listResult)
                {
                    values = item.Split(':');
                    if (propinfo.Name.ToLower() == values[0].ToLower())
                        propinfo.SetValue(evenSchedule, values[1], null);
                }
            }

            if (string.IsNullOrEmpty(evenSchedule.Message))
            {
                startDate.Text = evenSchedule.StartDate;
                starttime.Text = evenSchedule.StartTime;
                programname.Text = evenSchedule.ProgramName;
                presenter.Text = evenSchedule.Presenter;
                description.Text = evenSchedule.Description;
                location.Text = evenSchedule.Location;
            }
            else
                MessageBox.Show(evenSchedule.Message);
            

        }

    }
}