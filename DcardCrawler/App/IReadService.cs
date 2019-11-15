using DcardCrawler.Model;
using System.Collections.Generic;

namespace DcardCrawler.App
{
    public interface IReadService
    {
        ICollection<ListViewModel> ReadFromForums();

        PostViewModel ReadPost(string id);
    }
}