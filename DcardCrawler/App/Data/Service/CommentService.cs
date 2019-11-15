using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DcardCrawler.Model;
using Newtonsoft.Json;

namespace DcardCrawler.App.Data.Service
{
    public class CommentService : ICommentService
    {
        public ICollection<CommentViewModel> ReadFromPost(string id, int count)
        {
            int current = 0;
            var models = new List<CommentViewModel>();
            var url = $"https://www.dcard.tw/_api/posts/{id}/comments?after=";
            do
            {
                var responseString = Common.GetWebResponseString(url + current);
                if (!string.IsNullOrEmpty(responseString))
                {
                    try
                    {
                        var tmp = JsonConvert.DeserializeObject<List<CommentViewModel>>(responseString);
                        models.AddRange(tmp);
                        current += 30;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            } while (current < count);

            return models;
        }
    }
}