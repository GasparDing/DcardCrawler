using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DcardCrawler.Test
{
    [TestFixture]
    public class CrawlerTest
    {
        public CrawlerTest()
        {
        }

        [Test]
        public void DcardCrawlerTest()
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/f/sex") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }
        }
    }
}
