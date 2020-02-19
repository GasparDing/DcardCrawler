using DcardCrawler.Model;
using System.Collections.Generic;

namespace DcardCrawler.App
{
    public interface IPostService
    {
        ICollection<ListViewModel> ReadFromForums();

        PostViewModel ReadPost(string id);
             
    }
}