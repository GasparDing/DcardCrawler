using DcardCrawler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DcardCrawler.App.Data.Service
{
    public class ReadService : IReadService
    {
        // todo: 目前只能讀30筆，如何連續讀取後面的
        public ICollection<ListViewModel> ReadFromForums()
        {
            ICollection<ListViewModel> models = null;

            var responseString = Common.GetWebResponseString("https://www.dcard.tw/_api/forums/sex/posts?popular=false&limit=30");
            if (!string.IsNullOrEmpty(responseString))
            {
                try
                {
                    models = JsonConvert.DeserializeObject<List<ListViewModel>>(responseString);
                }
                catch (Exception e)
                {
                    //todo: 錯誤處理
                }
            }

            return models;
        }

        public PostViewModel ReadPost(string id)
        {
            var responseString = Common.GetWebResponseString($"https://www.dcard.tw/_api/posts/{id}");
            if (!string.IsNullOrEmpty(responseString))
            {
                PostViewModel model = null;
                try
                {
                    model = JsonConvert.DeserializeObject<PostViewModel>(responseString);
                }
                catch (Exception e)
                {
                    //todo: 錯誤處理
                }

                return model;
            }

            return null;
        }
    }
}