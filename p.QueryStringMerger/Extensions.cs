using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace p.QueryStringMerger
{
    public static class Extensions
    {
        public static string ToQueryString(this NameValueCollection collection)
        {
            string[] keyValues = (
                from string key in collection
                let values = collection.GetValues(key)
                where key != null && values != null
                select string.Format("{0}={1}", HttpUtility.UrlEncode(key, Encoding.UTF8), HttpUtility.UrlEncode(values.FirstOrDefault()))
                ).ToArray();

            return String.Join("&", keyValues);
        }
    }
}