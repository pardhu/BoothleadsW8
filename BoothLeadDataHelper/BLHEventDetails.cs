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
using System.Collections.ObjectModel;

namespace BoothLeads.BoothLeadDataHelper
{
    public class BLHEventDeail : BLBaseClass
    {
        public BLHelperResponse SaveEventDetail(BldbEventdetails eventSchedule)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbEventdetails>();
                string colnameForValue = GetColumns<BldbEventdetails>("@");

                string dbQuery = " Insert into eventdetails("+ colnames +") values("+ colnameForValue +")";
                int iResult = (Application.Current as App).db.Insert<BldbEventdetails>(eventSchedule, dbQuery);
                response.Code = iResult > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Event details saved successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }
        }

        public BLHelperResponse DeleteEventdetails()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From eventdetails";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Event details deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public ObservableCollection<BldbEventdetails> GetEventDetails(string userid, string eventid)
        {
            ObservableCollection<BldbEventdetails> eventdetailList = null;
            try
            {
                string columns = GetColumns<BldbEventdetails>();
                eventdetailList = new ObservableCollection<BldbEventdetails>();
                string dbQuery = " Select " + columns  + " from eventdetails where EDid = '" + eventid + "' and UserId='" + userid + "'";
                eventdetailList = (Application.Current as App).db.SelectObservableCollection<BldbEventdetails>(dbQuery);
                return eventdetailList;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

    }
}
