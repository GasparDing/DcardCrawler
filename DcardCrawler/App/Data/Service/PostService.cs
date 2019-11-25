using AutoMapper;
using DcardCrawler.Data;
using DcardCrawler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace DcardCrawler.App.Data.Service
{
    public class PostService : IPostService
    {
        // 如何讀取後面的 : 記住上一次撈的最後一筆Id，在API網址後面加上before
        // 例如 : https://www.dcard.tw/_api/posts?popular=true&limit=30&before=232498887
        public ICollection<ListViewModel> ReadFromForums()
        {
            ICollection<ListViewModel> models = null;

            var responseString = Common.GetWebResponseString("https://www.dcard.tw/_api/forums/sex/posts?popular=false&limit=30");
            //var responseString = Common.GetWebResponseString("https://www.dcard.tw/_api/posts?popular=true&limit=30");
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

                var entity = Initial.Mapper.Map<Post>(model);

                return model;
            }

            return null;
        }
    }

}