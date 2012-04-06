using System;

namespace Molibar.Common
{
    public class DataConverter
    {
        public static short ToInt16(string s)
        {
            short value;
            short.TryParse(s, out value);
            return value;
        }

        public static int ToInt32(string s)
        {
            int value;
            int.TryParse(s, out value);
            return value;
        }

        public static long ToInt64(string s)
        {
            long value;
            long.TryParse(s, out value);
            return value;
        }

        public static char ToChar(string s)
        {
            char value;
            char.TryParse(s, out value);
            return value;
        }

        public static double ToDouble(string s)
        {
            double value;
            double.TryParse(s, out value);
            return value;
        }

        public static decimal ToDecimal(string s)
        {
            decimal value;
            decimal.TryParse(s, out value);
            return value;
        }

        public static DateTime ToDateTime(string s)
        {
            DateTime value;
            DateTime.TryParse(s, out value);
            return value;
        }

        public static bool ToBoolean(string s)
        {
            bool value;
            bool.TryParse(s, out value);
            return value;
        }

        public static Guid ToGuid(string s)
        {
            Guid value;
            Guid.TryParse(s, out value);
            return value;
        }




        public static int? ToNullableInt32(string value)
        {
            if (value == null) return null;
            return Convert.ToInt32(value);
        }

        public static short? ToNullableInt16(string value)
        {
            if (value == null) return null;
            return Convert.ToInt16(value);
        }

        public static long? ToNullableInt64(string value)
        {
            if (value == null) return null;
            return Convert.ToInt64(value);
        }

        public static Guid? ToNullableGuid(string value)
        {
            if (value == null) return null;
            Guid guid;
            if (Guid.TryParse(value, out guid)) return guid;
            throw new FormatException("Input string was not in a correct format.");
        }

        public static bool? ToNullableBoolean(string value)
        {
            if (value == null) return null;
            bool boolean;
            if (bool.TryParse(value, out boolean)) return boolean;
            throw new FormatException("Input string was not in a correct format.");
        }

        public static T ToEnum<T>(Type enumType, string value)
        {
            if (value == null) return default(T);
            return (T)Enum.Parse(enumType, value);
        }
    }
}
