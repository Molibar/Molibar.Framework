using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Molibar.Common
{
    public class StringTools
    {
        public static String Left(String input, int length)
        {
            if (input == null)
                throw new ArgumentException("Input parameter cannot be null");

            if (length < 0)
                throw new ArgumentException("Length parameter must be greater than zero");

            if (input.Length == 0 || length == 0)
                return String.Empty;

            if (input.Length <= length)
                return input;

            return input.Substring(0, length);
        }

        /// <summary>
        /// If "application/page.aspx?user=bill" is sent in and c = '?' then "application/page.aspx" will be returned.
        /// </summary>
        /// <param name="c">the char to begin stripping from</param>
        /// <param name="str">the string to strip away the ending from</param>
        /// <returns>The stripped string</returns>
        public static string StripFromChar(char c, string str)
        {
            if (str == null) throw new ArgumentException("The argument str is null");
            int idx = str.IndexOf(c);
            if (idx < 0) return str;
            return str.Substring(0, idx);
        }


        public static string EncodeBase64(string uncoded)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(uncoded));
        }

        public static string DecodeBase64(string encoded)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }


        public static string Substring(string fullString, int maxLength)
        {
            return fullString.Length > maxLength ? fullString.Remove(maxLength) : fullString;
        }


        public static string PadValue(int value, int requiredLength,
            char character = '0', Location location = Location.Prepend)
        {
            var valueAsString = value.ToString(CultureInfo.InvariantCulture);
            var requiredPadding = requiredLength - valueAsString.Length;
            var padding = new string(character, requiredPadding);
            return (location == Location.Prepend)
                ? string.Concat(padding, valueAsString)
                : string.Concat(valueAsString, padding);
        }


        public static object StripNonNumeric(String input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null");

            String result = Regex.Replace(input, "[^.0-9]", "");

            if (!String.IsNullOrEmpty(result))
                return result;

            return null;
        }
    }

    public enum Location
    {
        Prepend,
        Append
    }
}
