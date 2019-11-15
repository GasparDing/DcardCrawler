using DcardCrawler.App;
using DcardCrawler.App.Data.Service;
using DcardCrawler.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace DcardCrawler.Test
{
    [TestFixture]
    public class CrawlerTest
    {
        public string Id = "232499265";
        private readonly IReadService ReadService;
        public CrawlerTest()
        {
            this.ReadService = new ReadService();
        }

        [Test]
        public void ReadFromForumsTest()
        {
            var models = this.ReadService.ReadFromForums();
        }

        [Test]
        public void ReadPostTest()
        {
            var models = new List<PostViewModel>();
            foreach (var listItem in this.ReadService.ReadFromForums())
            {
                var model = this.ReadService.ReadPost(listItem.Id);
                if (model != null)
                {
                    //models.Add(model);

                    // test download image
                    if (model.MediaMeta != null && model.MediaMeta.Count() > 0)
                    {
                        if (!Directory.Exists($"C:\\DcardSex\\{model.Id}"))
                            Directory.CreateDirectory($"C:\\DcardSex\\{ model.Id}");

                        int i = 0;
                        foreach (var media in model.MediaMeta)
                        {
                            WebClient webClient = new WebClient();
                            webClient.DownloadFile(media.Url, $"C:\\DcardSex\\{ model.Id}\\{model.Id}_{i}.jpg");
                            i++;
                        }
                    }
                }
            }

            Console.WriteLine("Finished");
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
