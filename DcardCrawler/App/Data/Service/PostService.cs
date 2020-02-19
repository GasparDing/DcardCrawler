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
    public class PostService : IApiService<string, PostViewModel>, IPostService
    {
        public bool Create(PostViewModel model)
        {
            var context = new CrawlerDbContext();
            var post = context.Posts.SingleOrDefault(p => p.Id == model.Id);
            if (post != null)
                return false;

            //Mapper.CreateMap<PostViewModel, Post>();
            var entity = new Post
            {
                Id = model.Id,
                Title = model.Title,

            };

            bool result = false;
            try
            {
                context.SaveChanges();
                result = true;
            }
            catch { }

            return result;
        }

        public ICollection<PostViewModel> Read()
        {
            throw new NotImplementedException();
        }

        public bool? Update(string key)
        {
            throw new NotImplementedException();
        }

        public bool? Delete(string key)
        {
            throw new NotImplementedException();
        }

        // 如何讀取後面的 : 記住上一次撈的最後一筆Id，在API網址後面加上before
        // 例如 : https://www.dcard.tw/_api/posts?popular=true&limit=30&before=232498887
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
                    var entity = Initial.Mapper.Map<Post>(model);
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