using DcardCrawler.App.Data.Service;

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
            var models = readService.ReadFromForums();
        }
    }
}