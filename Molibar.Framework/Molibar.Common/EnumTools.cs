using System;
using System.ComponentModel;

namespace Molibar.Common
{
    public static class EnumTools
    {
        public static string GetValue(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

        public static object GetValue(string value, Type enumType)
        {
            var names = Enum.GetNames(enumType);
            foreach (var name in names)
            {
                if (GetValue((Enum)Enum.Parse(enumType, name)).Equals(value))
                {
                    return Enum.Parse(enumType, name);
                }
            }
            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }
}