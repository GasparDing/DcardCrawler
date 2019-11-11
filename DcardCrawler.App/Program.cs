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

            // 撈取新文章，創建時間為一次interval 之前的，直接把內容都撈回來儲存

            // 用舊的文章去看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試

            // 用舊的留言去撈看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試
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