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
using BoothLeads.BoothLeadsEntity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BoothLeads.BoothLeadDataHelper
{
    public class BLHAttendeeDetails : BLBaseClass
    {
        public BLHelperResponse AddAttendeeDetails(BldbAttendeeDetails attendee)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Insert into AttendeeDetails("+ colnames +") Values("+ colnameForValue +")";
                int rec = (Application.Current as App).db.Insert<BldbAttendeeDetails>(attendee, dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Attendee details addedd successfully";
                return response;
            }
            catch(Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public BLHelperResponse DeleteAttendeeDetails()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From AttendeeDetails";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Attendee details deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public ObservableCollection<BldbAttendeeDetails> GetAttendeeDetails()
        {
            ObservableCollection<BldbAttendeeDetails> attendeeeList = null;
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                attendeeeList = new ObservableCollection<BldbAttendeeDetails>();
                string dbQuery = " Select " + colnames + " from AttendeeDetails ";
                attendeeeList = (Application.Current as App).db.SelectObservableCollection<BldbAttendeeDetails>(dbQuery);
                return attendeeeList;
            }
            catch (Exception excp)
            {
                throw excp;
            }

        }
    }
}
