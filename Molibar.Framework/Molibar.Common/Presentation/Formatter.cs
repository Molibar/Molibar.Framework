using System;
using System.Reflection;
using System.Text;

namespace Molibar.Common.Presentation
{
    public class Formatter
    {
        // Gets a formatting String representing a Type.
        public static String GetTypeFormatString(Type type)
        {
            var stringBuilder = new StringBuilder();

            // Build the format String for the declaring type.

            stringBuilder.Append(type.FullName);

            if (type.IsGenericTypeDefinition)
            {
                stringBuilder.Append("<");
                for (int i = 0; i < type.GetGenericArguments().Length; i++)
                {
                    if (i > 0)
                        stringBuilder.Append(", ");
                    stringBuilder.AppendFormat("{{{0}}}", i);
                }
                stringBuilder.Append(">");

            }
            return stringBuilder.ToString();
        }

        // Gets the formatting Strings representing a method.
        public static MethodFormatStrings GetMethodFormatStrings(MethodBase method)
        {
            var stringBuilder = new StringBuilder();

            string typeFormat = GetTypeFormatString(method.DeclaringType);

            // Build the format String for the method name.
            stringBuilder.Length = 0;
            stringBuilder.Append("::");
            stringBuilder.Append(method.Name);
            if (method.IsGenericMethodDefinition)
            {
                stringBuilder.Append("<");
                for (int i = 0; i < method.GetGenericArguments().Length; i++)
                {
                    if (i > 0)
                        stringBuilder.Append(", ");
                    stringBuilder.AppendFormat("{{{0}}}", i);
                }
                stringBuilder.Append(">");

            }
            string methodFormat = stringBuilder.ToString();

            // Build the format String for parameters.
            stringBuilder.Length = 0;
            ParameterInfo[] parameters = method.GetParameters();
            stringBuilder.Append("(");
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append("{{{");
                stringBuilder.Append(i);
                stringBuilder.Append("}}}");
            }
            stringBuilder.Append(")");

            string parameterFormat = stringBuilder.ToString();

            return new MethodFormatStrings(typeFormat, methodFormat, parameterFormat);
        }

        // Pads a String with a space, if not empty and not yet padded.
        public static String NormalizePrefix(String prefix)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return "";
            }

            if (prefix.EndsWith(" "))
            {
                return prefix;
            }

            return prefix + " ";
        }

        public static String FormatString(String format, Object[] args)
        {
            if (args == null)
            {
                return format;
            }

            return String.Format(format, args);
        }
    }
}
