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
using System.Collections.Generic;
using BoothLeads.BoothLeadsEntity;

namespace BoothLeads.ServiceClient.DataContracts
{
    public class UsersDetails
    {
        public string UserID { get; set; }
        public bool isfreeuser { get; set; }
        public string Event_StartDate { get; set; }
        public string Session_ID { get; set; }
        public string User_Login_Time { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public string ImageUrl { get; set; }
        public List<BldbEventdetails> Edetails { get; set; }

    }

    public class Article
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string EventName { get; set; }
    }
}
