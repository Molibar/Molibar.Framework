using System;

namespace Molibar.Infrastructure.DataAccess
{
    public class DBUtils
    {

        public static DateTime ConvertDBDateTime(object dbValue)
        {
            return ConvertDBDateTime(dbValue, DateTime.MinValue);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        public static bool ConvertDBBool(object dbValue, bool defaultValue = false)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToBoolean(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static DateTime ConvertDBDateTime(object dbValue, DateTime defaultValue)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToDateTime(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static double ConvertDBDouble(object dbValue, double defaultValue = 0d)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToDouble(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static decimal ConvertDBDecimal(object dbValue, decimal defaultValue = 0m)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToDecimal(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static int ConvertDBInt(object dbValue, int defaultValue = 0)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToInt32(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static short ConvertDBInt16(object dbValue, short defaultValue)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToInt16(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static long ConvertDBInt64(object dbValue, long defaultValue)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToInt64(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static char ConvertDBChar(object dbValue, char defaultValue = '\0')
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : Convert.ToChar(dbValue, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat);
        }

        public static string ConvertDBString(object dbValue, string defaultValue = null)
        {
            return ((dbValue == null) || (dbValue is DBNull)) ? defaultValue : dbValue.ToString();
        }





        public static object ToDBBool(bool? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBDateTime(DateTime? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBDouble(double? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBInt(int? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBInt16(short? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBInt64(long? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBChar(char? val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public static object ToDBString(string val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }
    }
}