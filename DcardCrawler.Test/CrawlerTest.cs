using DcardCrawler.App;
using DcardCrawler.App.Data.Service;
using DcardCrawler.Data;
using DcardCrawler.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            Initial.AutoMapper();
        }

        [Test]
        public void MapperTest()
        {
            var list = new List<TopicViewModel> {
                new TopicViewModel{ Value = "123"},
                new TopicViewModel{ Value = "234"},
                new TopicViewModel{ Value = "345"}
            };

            var topic = Initial.Mapper.Map<Topic>(list.First());
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
                    {
                        var models2 = this.CommentService.ReadFromPost(model.Id, model.CommentCount);
                    }

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

        [Test]
        public async Task PttTest()
        {
            var responseString = "";

            var request = WebRequest.Create("https://ppt.cc/fU5EEx") as HttpWebRequest;
            var boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.AllowWriteStreamBuffering = true;

            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            string header = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            var pair = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string,string>("url", "https://ppt.cc/fU5EEx"),
                new KeyValuePair<string,string>("ga", "1"),
                new KeyValuePair<string,string>("t", "2"),
                new KeyValuePair<string,string>("p", "123123"),
                new KeyValuePair<string,string>("https://ppt.cc/fU5EEx", "我要通關")
            };

            try
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                    foreach (var p in pair)
                    {
                        var format = string.Format(header, p.Key, p.Value);
                        var bytes = Encoding.UTF8.GetBytes(format);
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                    }
                    requestStream.Close();
                }

                // get xml
                var response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                        responseString = responseReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                responseString = e.Message;
            }

        }
        // ppt.cc 取得圖片
        /*
         POST https://ppt.cc/fU5EEx HTTP/1.1
Accept: text/html, application/xhtml+xml, image/jxr, 
Referer: https://ppt.cc/fU5EEx
Accept-Language: zh-Hant-TW,zh-Hant;q=0.8,en-US;q=0.5,en;q=0.3
User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko
Content-Type: multipart/form-data; boundary=---------------------------7e43ab390920
Accept-Encoding: gzip, deflate
Host: ppt.cc
Content-Length: 554
Connection: Keep-Alive
Cache-Control: no-cache
Cookie: PHPSESSID=r8l1jqm1cjeh30ub3t0t60tbd5

-----------------------------7e43ab390920
Content-Disposition: form-data; name="url"

https://ppt.cc/fU5EEx
-----------------------------7e43ab390920
Content-Disposition: form-data; name="ga"

1
-----------------------------7e43ab390920
Content-Disposition: form-data; name="t"

2
-----------------------------7e43ab390920
Content-Disposition: form-data; name="p"

123123
-----------------------------7e43ab390920
Content-Disposition: form-data; name="https://ppt.cc/fU5EEx"

我要通關
-----------------------------7e43ab390920--

        */
    }
}
