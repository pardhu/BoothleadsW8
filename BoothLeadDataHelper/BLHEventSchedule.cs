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
    public class BLHEventSchedule : BLBaseClass
    {
        public BLHelperResponse SaveEventSchedule(BldbEventSchedule eventSchedule)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbEventSchedule>();
                string colnameForValue = GetColumns<BldbEventSchedule>("@");

                string dbQuery = " Insert into EventSchedule("+ colnames +") values("+ colnameForValue +")";
                int iResult = (Application.Current as App).db.Insert<BldbEventSchedule>(eventSchedule, dbQuery);
                response.Code = iResult > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Event schedule saved successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public BLHelperResponse DeleteEventSchedule()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From EventSchedule";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Event schedule deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public ObservableCollection<BldbEventSchedule> GetEventDetails(string eventid)
        {
            ObservableCollection<BldbEventSchedule> evenScheduleList = null;
            try
            {
                string colnames = GetColumns<BldbEventSchedule>();
                evenScheduleList = new ObservableCollection<BldbEventSchedule>();
                string dbQuery = " Select " + colnames  + " from EventSchedule where EsId='" + eventid + "'";
                evenScheduleList = (Application.Current as App).db.SelectObservableCollection<BldbEventSchedule>(dbQuery);
                return evenScheduleList;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }


    }
}
