using DcardCrawler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DcardCrawler.App.Data.Service
{
    public class ReadService : IReadService
    {
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
    }
}