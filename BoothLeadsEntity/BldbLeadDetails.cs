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
    public class BLDBLeadDetails
    {
        public string LeadID { get; set; }
        public string UserID { get; set; }
        public string EventID { get; set; }
        public string ImageURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime FollowUPDate { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
        public string FBStatus { get; set; }
        public string TwitterStatus { get; set; }
        public string LinkedinStatus { get; set; }
        public string SalesForceStatus { get; set; }
        public string EmailStatus { get; set; }
        public string SyncStatus { get; set; }
        public string ReminderStatus { get; set; }
        public int FollowUPTypeID { get; set; }
        public string SurveyQuestion1 { get; set; }
        public string SurveyQuestion2 { get; set; }
        public string SurveyQuestion3 { get; set; }
        public string SurveyQuestion4 { get; set; }
        public string SurveyQAnswer1 { get; set; }
        public string SurveyQAnswer2 { get; set; }
        public string SurveyQAnswer3 { get; set; }
        public string SurveyQAnswer4 { get; set; }
        public int AtQRid { get; set; }
        public string ATBarcodeID { get; set; }
        public string barcodeId { get; set; }
        public string Title { get; set; }
    }
}
