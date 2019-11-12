using DcardCrawler.App.Data.Service;
using Quartz;
using Quartz.Impl;

namespace DcardCrawler.App
{
    class Program
    {
        private static IScheduler scheduler;

        static void Main(string[] args)
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();

            IJobDetail pullJob = JobBuilder.Create<PullJob>()
                .WithIdentity("pullJob", "pullGroup")
                .Build();

            ITrigger pullTrigger = TriggerBuilder.Create()
                .WithIdentity("pullTrigger", "pullGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(pullJob, pullTrigger);


            // 撈取新文章，創建時間為一次interval 之前的，直接把內容都撈回來儲存

            // 用舊的文章去看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試

            // 用舊的留言去撈看有沒有更新，如果有更新就寫一份新的，舊的Backup (可行性測試
            IReadService readService = new ReadService();
            var models = readService.ReadFromForums();
        }
    }
}