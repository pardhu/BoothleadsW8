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
    public class BLHUserInfo : BLBaseClass
    {
        public BLHelperResponse AddUserInfo(BldbUserInfo userDetail)
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbUserInfo>();
                string colnameForValue = GetColumns<BldbUserInfo>("@");

                string dbQuery = " Insert into UserInfo("+ colnames +") Values("+ colnameForValue +")";
                int iResult = (Application.Current as App).db.Insert<BldbUserInfo>(userDetail, dbQuery);
                response.Code = iResult > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Useinfo addedd successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }
        }

        public BLHelperResponse DeleteUserInfo()
        {
            BLHelperResponse response = new BLHelperResponse();
            try
            {
                string colnames = GetColumns<BldbAttendeeDetails>();
                string colnameForValue = GetColumns<BldbAttendeeDetails>("@");

                string dbQuery = " Delete From UserInfo";
                int rec = (Application.Current as App).db.Delete(dbQuery);
                response.Code = rec > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Userinfo deleted successfully";
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }

        }
        public BLHelperResponse DatabaseVaccum()
        {
            BLHelperResponse response = new BLHelperResponse();
            string dbQuery = string.Empty;
            try
            {

                int iResult = (Application.Current as App).db.Vaccum();
                response.Code = iResult > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Database has reclaimed the file size.";

                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }
        }

        public BLHelperResponse UpdateUserInfo(BldbUserInfo userDetail)
        {
            BLHelperResponse response = new BLHelperResponse();
            string dbQuery = string.Empty;
            try
            {
                dbQuery = " Update Userinfo ";
                PropertyInfo[] propertyList = userDetail.GetType().GetProperties();
                object propValue = null;
                foreach (PropertyInfo propinfo in propertyList)
                {
                    propValue = propinfo.GetValue(userDetail, null);
                    if (propValue != null && propinfo.Name != "Userid")
                        dbQuery += " Set " + propinfo.Name + " = '" + Convert.ToString(propValue) + "',";
                }
                if (dbQuery.EndsWith(","))
                    dbQuery = dbQuery.Substring(0, dbQuery.LastIndexOf(","));

                dbQuery += " where userid=" + userDetail.Userid;
                int iResult = (Application.Current as App).db.Update(dbQuery);
                response.Code = iResult > 0 ? GetSuccessCode : GetErrorCode;
                response.Message = "Useinfo addedd successfully";
                
                return response;
            }
            catch (Exception excp)
            {
                response.Code = GetErrorCode;
                response.Message = excp.Message;
                return response;
            }
        }

        public ObservableCollection<BldbUserInfo> GetUserDetails(string userid)
        {
            ObservableCollection<BldbUserInfo> userinforlist = null;
            try
            {
                string colnames = GetColumns<BldbUserInfo>();
                userinforlist = new ObservableCollection<BldbUserInfo>();
                //string dbQuery = " Select "+ colnames +" from Userinfo where userid='" + userid + "'";
                string dbQuery = " Select " + colnames + " from Userinfo";
                userinforlist = (Application.Current as App).db.SelectObservableCollection<BldbUserInfo>(dbQuery);
                return userinforlist;
            }
            catch (Exception excp)
            {
                throw excp;
            }
        }
    }
}
