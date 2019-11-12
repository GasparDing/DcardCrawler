using NUnit.Framework;
using System.IO;
using System.Net;

namespace DcardCrawler.Test
{
    [TestFixture]
    public class CrawlerTest
    {
        public string Id = "232067857";

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

        [Test]
        public void DcardCrawlerTest()
        {
            HttpWebRequest request = WebRequest.Create("https://www.dcard.tw/_api/posts/232044749") as HttpWebRequest;
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
