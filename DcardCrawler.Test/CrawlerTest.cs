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

        string Id = "231268139";
        public CrawlerTest()
        {
            
        }

        [Test]
        public void ListCrawlerTest()
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/forums/sex/posts?popular=true&limit=30") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }
        }

        [Test]
        public void PostCrawlerTest()
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/posts/231268139") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }
        }

         [Test]
        public void CommentCrawlerTest()
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
