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
using System.Reflection;
using System.Collections.ObjectModel;

namespace BoothLeads.BoothLeadDataHelper
{
    public class BLHLeadDetails : BLBaseClass
    {
        public BLHelperResponse SaveLeadDetails(BLDBLeadDetails leaddetails)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string columnName  = GetColumns<BLDBLeadDetails>();
                string columnForValue = GetColumns<BLDBLeadDetails>("@");
                string dbQuery = " Insert into leaddetails(" + columnName + ") values(" + columnForValue + ")";
                int iResult = (Application.Current as App).db.Insert<BLDBLeadDetails>(leaddetails, dbQuery);
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

        public BLHelperResponse DeleteLeadDetails()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From leaddetails";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Lead details deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public ObservableCollection<BLDBLeadDetails> GetEventLeads(string userid, string eventid)
        {
            ObservableCollection<BLDBLeadDetails> leadDetailList = null;
            try
            {
                string columnname = GetColumns<BLDBLeadDetails>();
                if (string.IsNullOrEmpty(columnname) == false)
                {
                    leadDetailList = new ObservableCollection<BLDBLeadDetails>();
                    string dbQuery = string.Empty;
                    if (string.IsNullOrEmpty(eventid))
                        dbQuery = " Select " + columnname + " from LeadDetails where UserID='" + userid + "'";
                    else
                        dbQuery = " Select " + columnname + " from LeadDetails where UserID='" + userid + "' and " + " EsId='" + eventid + "'";

                    leadDetailList = (Application.Current as App).db.SelectObservableCollection<BLDBLeadDetails>(dbQuery);
                }
                return leadDetailList;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }

        public ObservableCollection<BLDBLeadDetails> GetEventLeads(string userid)
        {
            return GetEventLeads(userid, null);
        }

    }


}
