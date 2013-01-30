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

namespace BoothLeads.ServiceClient
{
    public class SalesForceServiceURL
    {
        // Client code completed
        //public const string SVC_AUTHORIZATION_URL = "https://test.salesforce.com/services/oauth2/token?grant_type=password&client_id=3MVG9Nvmjd9lcjRmgXI5Kypycu6m1Q1k1rGrW5gcKWzyYTAPsuGEU6YvI6ITL4Wt3AZoFktNmadpNLXlExiLO&client_secret=4633981559206472014&username={0}&password={1}";
        public const string SVC_AUTHORIZATION_URL = "https://test.salesforce.com/services/oauth2/token?grant_type=password&client_id=3MVG9Nvmjd9lcjRmgXI5Kypycu6m1Q1k1rGrW5gcKWzyYTAPsuGEU6YvI6ITL4Wt3AZoFktNmadpNLXlExiLO&client_secret=4633981559206472014&username=durga@48demo.com.bleadtest&password=globalnest@281LBiouGUWvoHeJ140BOTH1bMe";
        //public const string SVC_AUTHORIZATION_USERNAME = "durga@48demo.com.bleadtest";
        //public const string SVC_AUTHORIZATION_PASSWORD = "blversion2jKkBj6kbJ9RIGlrsmd0ScG7H";
        // Client code completed
        //public const string SVC_LOGIN_URL = "https://boothleads.bleadtest.cs5.force.com/services/apexrest/LOGIN?EmailID={0}&Password={1}";
        public const string SVC_LOGIN_URL = "https://cs5.salesforce.com/services/apexrest/LOGIN?EmailID={0}&Password={1}";
        public const string SVC_FORGOTPASSWORD_URL = "https://cs5.salesforce.com/services/apexrest/RESETPASSWORD?Username={0}&OldPassword={1}&newPassword={2}";
        // Client code completed
        public const string SVC_EVENTDETAILS_URL = "https://cs5.salesforce.com/services/apexrest/EVENTDETAILS?UserID={0}&EventId={1}";
        // Client code completed
        public const string SVC_EVENTSCHEDULE_URL = "https://cs5.salesforce.com/services/apexrest/EVENTSCHEDULE?EventId={0}";
        // Client code completed
        public const string SVC_EVENT_EXHIBITORS_URL = "https://cs5.salesforce.com/services/apexrest/EVENTEXHIBITORS?UserID={0}&EventId={1}";
        // Client code completed
        public const string SVC_VERIFYLEADS_URL = "https://cs5.salesforce.com/services/apexrest/VERIFYLEAD?EventId={0}&UserId={1}&QRcode={2}";
        // Client code completed
        public const string SVC_SYNCHLEADS_URL = "https://cs5.salesforce.com/services/apexrest/SYNCHLEADS?EventId={0}&UserId={1}";
        // Client code completed
        public const string SVC_DATAREADY_URL = "https://cs5.salesforce.com/services/apexrest/DATAREADY?EventId={0}&UserId={1}&AttCount={2}&ExtCount={3}";
        // Client code completed
        public const string SVC_GETLEADS_URL = "https://cs5.salesforce.com/services/apexrest/getLeads?EventId={0}&UserId={1}";
        // Client code completed
        public const string SVC_GETLEAD_URL = "https://cs5.salesforce.com/services/apexrest/getLeads?EventId={0}&UserId={1}";
        public const string SVC_DEVICE_USAGE_URL = "https://cs5.salesforce.com/services/apexrest/DeviceUsage?EventId={0}&UserID={1}&IMEI={2}&OSversion={3}";
        // Client code completed
        public const string SVC_SAVE_USER_PROFILE_URL = "https://cs5.salesforce.com/services/apexrest/SaveUserProfile?UserID={0}&Firstname={1}&Lastname={2}&Company={3}&city={4}&state={5}&phoneno={6}";

    }

}
