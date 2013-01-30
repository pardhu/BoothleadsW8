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
    public class BldbUserInfo
    {
        public string Userid { get; set; }
        public string Accounttype { get; set; }
        public string CheckinEventID { get; set; }
        public string CheckOutEventID { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FBID { get; set; }
        public string TwitterID { get; set; }
        public string LinkedInID { get; set; }
        public string FourSquareID { get; set; }
        public string Password { get; set; }
    }
}
