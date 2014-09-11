using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p.QueryStringMerger.Test
{
    [TestClass]
    public class QueryStringManagerTest
    {
        private string Url { get; set; }
        private string Query { get; set; }

        private IQueryStringManager Manager;

        [TestInitialize]
        public void Initialize()
        {
            Manager = new QueryStringManager();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUrl_Url_Is_Null()
        {
            Manager.CreateUrl(Url, Query);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUrl_Url_Is_NotNull_Query_Is_Null()
        {
            Url = "http://www.housepasa.com?k=val1&k2=val2";

            Manager.CreateUrl(Url, Query);
        }

        [TestMethod]
        public void CreateUrl_Url_Is_NotNull_Query_Is_NotNull_Returns_Result_NotNull()
        {
            Url = "http://www.housepasa.com?k=val1&k2=val2";
            Query = "k3=val3";
            string result = Manager.CreateUrl(Url, Query);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Contains("??"));
        }  
        
        [TestMethod]
        public void CreateUrl_Url_Is_NotNull_Query_Has_EncodedValue()
        {
            Url = "http://www.housepasa.com?k=val1&k2=val2%26";
            Query = "k3=+%23%24%25%26%27()*%2b%2c-.";
            string result = Manager.CreateUrl(Url, Query);
            Assert.IsTrue(result.Contains("k=val1&k2=val2%26"));
            Assert.IsTrue(result.Contains(Query));
        }
    }
}
