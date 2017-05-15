using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webcontrol
{
    public static class UrlUtilities
    {
        public static bool TryMakeURLValid(string url)
        {
            if (url.IndexOf('.') == -1)
                return false;

            url = UrlUtilities.AddPrefixes(url);

            Uri uriResult;

            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public static string AddPrefixes(string url)
        {
            if (url.Contains("https"))
                return PutAfterOrAtStart(url, "https://", "www.");
            else
                return PutAfterOrAtStart(url, "http://", "www.");
        }

        public static string PutAfterOrAtStart(string url, string stringBefore, string stringToInput)
        {
            int index = url.IndexOf(stringBefore);
            if (index + stringBefore.Length == url.Length) return url + stringToInput;
            if (index == -1)
                return stringBefore + stringToInput + url;
            else
                return stringBefore + stringToInput + url.Remove(index, stringBefore.Length);
        }
    }
}
