using DcardCrawler.Model;
using System.Collections.Generic;

namespace DcardCrawler.App
{
    public interface ICommentService
    {
        ICollection<CommentViewModel> ReadFromPost(string id, int count);
    }
}
