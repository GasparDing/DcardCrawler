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
            //HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/f/sex") as HttpWebRequest;
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/posts/231223641") as HttpWebRequest;
            WebResponse response = null;

            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError && e.Response != null)
                {
                    var resp = (HttpWebResponse)e.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Do something
                    }
                    else
                    {
                        // Do something else
                    }
                }
                else
                {
                    // Do something else
                }
            }

            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }
        }
    }
}
