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

        string Id = "232067857";
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
            HttpWebRequest request = WebRequest.Create($"https://www.dcard.tw/_api/posts/{Id}") as HttpWebRequest;
            var response = request.GetResponse();
            string responseString = null;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                    responseString = streamReader.ReadToEnd();
            }

            //// testing download image
            //if (models != null)
            //{
            //    foreach (var m in models)
            //    {
            //        foreach (var media in m.MediaMeta)
            //        {
            //            WebClient webClient = new WebClient();
            //            webClient.DownloadFile(media.Url, $"./{media.Id}.jpg");
            //        }
            //    }
            //}
        }

        [Test]
        public void CommentCrawlerTest()
        {
            HttpWebRequest request = WebRequest.Create($"https://www.dcard.tw/_api/posts/{Id}/comments") as HttpWebRequest;
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
