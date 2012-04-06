using System;
using System.Text;
using Molibar.Infrastructure.Logging;

namespace Molibar.Common.Web
{
    public class UriHelper
    {
        public static Uri Combine(string firstPart, string lastPart)
        {
            if (firstPart == null)
            {
                Log.FatalMessage(typeof(UriHelper), "Maybe ImageSettings.LogoBaseUrl wasn't initialized?");
                throw new ArgumentNullException("firstPart");
            }
            var sb = new StringBuilder(firstPart);
            var firstPartEndsWithSlash = sb[sb.Length - 1] == '/';
            var lastPartStartsWithSlash = lastPart.StartsWith("/");
            if (firstPartEndsWithSlash)
            {
                // if firstPart ends with '/' and lastPart starts with '/' then
                // one should skip the first '/' from the lastPart.
                sb.Append(lastPartStartsWithSlash ? lastPart.Substring(1) : lastPart);
            }
            else
            {
                // if firstPart doesn't end with '/' and lastPart doesn't start
                // with '/' one should append a '/' before appending lastPart.
                if (lastPartStartsWithSlash) sb.Append(lastPart);
                else sb.Append("/").Append(lastPart);
            }
            var uri = new Uri(sb.ToString());
            return uri;
        }

        public static String GetDomain(Uri url)
        {
            if (url == null)
                throw new ArgumentException("Null Uri object supplied. Please enter a valid Url");

            String portNumber = String.Empty;
            if (url.Authority.Contains(":"))
                portNumber = url.Authority.Substring(url.Authority.IndexOf(":"), url.Authority.Length - url.Authority.IndexOf(":"));

            if (url.Authority.Contains("www."))
            {
                if (String.IsNullOrEmpty(portNumber))
                    return url.Authority.Replace("www.", String.Empty);
                else
                    return url.Authority.Replace("www.", String.Empty).Replace(portNumber, String.Empty);
            }
            else
            {
                String[] splitUrl = url.Authority.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

                switch (splitUrl.Length)
                {
                    case 2:
                        if (String.IsNullOrEmpty(portNumber))
                            return String.Format("{0}.{1}", splitUrl[0], splitUrl[1]);
                        else
                            return String.Format("{0}.{1}", splitUrl[0], splitUrl[1].Replace(portNumber, String.Empty));
                    case 3:
                        if (splitUrl[0] == "www" || splitUrl[0] == "dev" || splitUrl[0] == "stage")
                        {
                            if (String.IsNullOrEmpty(portNumber))
                                return String.Format("{0}.{1}", splitUrl[1], splitUrl[2]);
                            else
                                return String.Format("{0}.{1}", splitUrl[1],
                                                     splitUrl[2].Replace(portNumber, String.Empty));
                        }
                        else
                        {
                            if (splitUrl[1] != "co" && splitUrl[2] != "uk")
                            {
                                if (String.IsNullOrEmpty(portNumber))
                                    return String.Format("{0}.{1}", splitUrl[1], splitUrl[2]);
                                else
                                    return String.Format("{0}.{1}", splitUrl[1],
                                                         splitUrl[2].Replace(portNumber, String.Empty));
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(portNumber))
                                    return String.Format("{0}.{1}.{2}", splitUrl[0], splitUrl[1], splitUrl[2]);
                                else
                                    return String.Format("{0}.{1}.{2}", splitUrl[0], splitUrl[1],
                                                         splitUrl[2].Replace(portNumber, String.Empty));
                            }
                        }
                    case 4:
                        if (splitUrl[0] == "www")
                        {
                            if (String.IsNullOrEmpty(portNumber))
                                return String.Format("{0}.{1}", splitUrl[2], splitUrl[3]);
                            else
                                return String.Format("{0}.{1}", splitUrl[2],
                                                     splitUrl[3].Contains(portNumber)
                                                         ? splitUrl[3].Replace(portNumber, String.Empty)
                                                         : splitUrl[3]);
                        }
                        else
                        {
                            if (splitUrl[0] == "dev" || splitUrl[0] == "stage")
                            {
                                if (String.IsNullOrEmpty(portNumber))
                                    return String.Format("{0}.{1}", splitUrl[2], splitUrl[3]);
                                else
                                    return String.Format("{0}.{1}", splitUrl[2], splitUrl[3].Replace(portNumber, String.Empty));
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(portNumber))
                                    return String.Format("{0}.{1}.{2}", splitUrl[1], splitUrl[2], splitUrl[3]);
                                else
                                    return String.Format("{0}.{1}.{2}", splitUrl[1], splitUrl[2],
                                                         splitUrl[3].Contains(portNumber)
                                                             ? splitUrl[3].Replace(portNumber, String.Empty)
                                                             : splitUrl[3]);
                            }
                        }
                    case 5:
                        if (String.IsNullOrEmpty(portNumber))
                            return String.Format("{0}.{1}.{2}", splitUrl[2], splitUrl[3], splitUrl[4]);
                        else
                            return String.Format("{0}.{1}.{2}", splitUrl[2], splitUrl[3], splitUrl[4].Replace(portNumber, String.Empty));
                    default:
                        return String.Empty;
                }
            }
        }
    }
}