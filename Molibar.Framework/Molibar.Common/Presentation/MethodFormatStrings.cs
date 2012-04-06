using System;
using System.Reflection;

namespace Molibar.Caching.PostSharp
{
    [Serializable]
    public class MethodFormatStrings
    {
        private readonly String _typeFormat;
        private readonly String _methodFormat;
        private readonly String _parameterFormat;

        public MethodFormatStrings(String typeFormat, String methodFormat, String parameterFormat)
        {
            _typeFormat = typeFormat;
            _methodFormat = methodFormat;
            _parameterFormat = parameterFormat;
        }

        public String Format(
            Object instance,
            MethodBase method,
            Object[] invocationParameters)
        {
            String[] parts = { 
                                 Formatter.FormatString(_typeFormat, method.DeclaringType.GetGenericArguments()),
                                 Formatter.FormatString(_methodFormat, method.GetGenericArguments()),
                                 instance == null ? "" : String.Format("{{{0}}}", instance ),
                                 Formatter.FormatString(_parameterFormat, invocationParameters) };

            return String.Concat(parts);
        }
    }
}