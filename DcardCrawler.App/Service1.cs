using DcardCrawler.App.Data.Service;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DcardCrawler.App
{
    public partial class Service1 : ServiceBase
    {
        private static IScheduler scheduler;

        public Service1()
        {
            

            InitializeComponent();

            scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();

            IJobDetail pullJob = JobBuilder.Create<PullJob>()
                .WithIdentity("pullJob", "pullGroup")
                .Build();
            ITrigger pullTrigger = TriggerBuilder.Create()
                .WithIdentity("pullTrigger", "pullGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)  // interval setting 
                    .RepeatForever())
                .Build();
            scheduler.ScheduleJob(pullJob, pullTrigger);
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
