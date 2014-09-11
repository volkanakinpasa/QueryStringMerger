using System;
using System.Collections.Specialized;
using System.Web;

namespace p.QueryStringMerger
{
    public class QueryStringManager : IQueryStringManager
    {
        /// <summary>
        /// Creates full url with queryString
        /// </summary>
        /// <param name="url">url with or without query</param>
        /// <param name="queryString">query string that you want to append to the url</param>
        /// <returns></returns>
        public string CreateUrl(string url, string queryString)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            if (string.IsNullOrWhiteSpace(queryString)) throw new ArgumentNullException("queryString");

            UriBuilder uriBuilder = new UriBuilder(url);

            NameValueCollection collection = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(uriBuilder.Query))
            {
                collection.Add(ParseQueryString(uriBuilder.Query));
            }

            collection.Add(ParseQueryString(queryString));

            uriBuilder.Query = collection.ToQueryString();

            url = uriBuilder.ToString();

            return url;
        }

        private static NameValueCollection ParseQueryString(string queryString)
        {
            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(queryString);
            return queryStringCollection;
        }
    }
}
