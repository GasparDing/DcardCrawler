using DcardCrawler.App.Data.Service;
using Quartz;
using System;
using System.Threading.Tasks;

namespace DcardCrawler.App
{
    public class PullJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            IPostService postService = new PostService();

            // 撈取新文章List，創建時間為一次interval 之前的，直接把內容都撈回來儲存
            var list = postService.ReadFromForums();
            // 撈取Post 並寫到
            foreach (var item in list)
            {
                var post = postService.ReadPost(item.Id);
                postService.Create(post);
            }



            // 用舊的文章去看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試

            // 用舊的留言去撈看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試



            throw new NotImplementedException();
        }
    }
}
