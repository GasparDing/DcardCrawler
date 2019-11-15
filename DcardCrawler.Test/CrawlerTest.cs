using DcardCrawler.App;
using DcardCrawler.App.Data.Service;
using DcardCrawler.Model;
using Newtonsoft.Json;
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
        private readonly IPostService PostService;
        private readonly ICommentService CommentService;
        public CrawlerTest()
        {
            this.PostService = new PostService();
            this.CommentService = new CommentService();
        }

        [Test]
        public void ReadFromForumsTest()
        {
            var models = this.PostService.ReadFromForums();
        }

        [Test]
        public void ReadPostTest()
        {
            var models = new List<PostViewModel>();
            foreach (var listItem in this.PostService.ReadFromForums())
            {
                var model = this.PostService.ReadPost(listItem.Id);
                if (model != null)
                {
                    Console.WriteLine(model.Id + " Start");
                    //models.Add(model);
                    if (model.CommentCount > 0)
                        this.CommentService.ReadFromPost(model.Id, model.CommentCount);

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

                    Console.WriteLine(model.Id + " End");
                }
            }

            Console.WriteLine("Finished");
        }

        [Test]
        public void CommentCrawlerTest()
        {
            var models = this.CommentService.ReadFromPost("", 1);
        }
    }
}
