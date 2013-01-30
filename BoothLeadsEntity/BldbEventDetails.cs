using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BoothLeads.BoothLeadsEntity
{
    public class BldbEventdetails
    {
        public string Status { get; set; }
        public string HostingZipcode { get; set; }
        public string HostingState { get; set; }
        public string HostingPhone { get; set; }
        public string HostingCountry { get; set; }
        public string HostingCity { get; set; }
        public string HostingAddr2 { get; set; }
        public string HostingAddr1 { get; set; }
        public string EventLogoImageURL { get; set; }
        public string Event_StartHour { get; set; }
        public string Event_StartDate { get; set; }
        public string Event_Name { get; set; }
        public string Event_Location { get; set; }
        public string Event_ID { get; set; }
        public string Event_EndHour { get; set; }
        public string Event_Description { get; set; }
        public string Event_Date { get; set; }
    }
}
