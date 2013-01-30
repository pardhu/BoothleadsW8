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
using System.Reflection;

namespace BoothLeads.BoothLeadDataHelper
{
    public abstract class BLBaseClass
    {
        protected int GetErrorCode
        {
            get
            {
                return -1;
            }
        }

        protected int GetSuccessCode
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Method to get all fields name for database query column name for given type (model/entity)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected string GetColumns<T>()
        {
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
            return GetColumnName(properties, null);
        }

        /// <summary>
        // Method to get all fields name for database query column name for given type (model/entity)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colForValue"></param>
        /// <returns></returns>
        protected string GetColumns<T>(string colForValue)
        {
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
            return GetColumnName(properties, colForValue);
        }

        private string GetColumnName(PropertyInfo[] properties, string colForValue)
        {
            string columnname = string.Empty;
            foreach (PropertyInfo propinfo in properties)
            {
                if (string.IsNullOrEmpty(colForValue))
                    columnname += propinfo.Name + ",";
                else
                    columnname += colForValue + propinfo.Name + ",";
            }
            if (columnname.EndsWith(","))
                columnname = columnname.Substring(0, columnname.LastIndexOf(","));

            return columnname;
        }
        
    }
}
