using DcardCrawler.App.Data.Model;
using DcardCrawler.App.Data.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace DcardCrawler.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadService readService = new ReadService();
            var responseString = readService.ReadFromCategory();
            if (!string.IsNullOrEmpty(responseString))
            {
                ICollection<ListViewModel> models = null;
                try
                {
                    models = JsonConvert.DeserializeObject<List<ListViewModel>>(responseString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}] ErrorMessage: {ex.Message}");
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
            else
            {
                Console.WriteLine($"[{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}] responseString is null");
            }
        }
    }
}