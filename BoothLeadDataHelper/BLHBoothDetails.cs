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
    public class BLHBoothDetails : BLBaseClass
    {
        public BLHelperResponse SaveBoothDetails(BldbBoothDetails attendee)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbBoothDetails>();
                string colnameForValue = GetColumns<BldbBoothDetails>("@");

                string dbQuery = " Insert into BoothDetails(" + colnames + ") Values(" + colnameForValue + ")";
                int rec = (Application.Current as App).db.Insert<BldbBoothDetails>(attendee, dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Booth details addedd successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public BLHelperResponse DeleteBoothDetails()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From BoothDetails";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Booth details deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }

        public ObservableCollection<BldbBoothDetails> GetBoothDetails()
        {
            ObservableCollection<BldbBoothDetails> boothdetaillist = null;
            try
            {
                string colnames = GetColumns<BldbBoothDetails>();
                boothdetaillist = new ObservableCollection<BldbBoothDetails>();
                string dbQuery = " Select " + colnames + " from BoothDetails ";
                boothdetaillist = (Application.Current as App).db.SelectObservableCollection<BldbBoothDetails>(dbQuery);
                return boothdetaillist;
            }
            catch (Exception excp)
            {
                throw excp;
            }

        }
    }
}
