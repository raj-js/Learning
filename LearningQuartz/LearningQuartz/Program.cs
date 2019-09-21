using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace LearningQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            {
                var props = new NameValueCollection
                {
                    {"quartz.serializer.type", "binary"}
                };
                var factory = new StdSchedulerFactory(props);

                var schedule = await factory.GetScheduler();

                await schedule.Start();

                var job = JobBuilder.Create<SimpleJob>()
                    .WithIdentity("startup_job", "startup")
                    .Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity("startup_trigger", "startup")
                    .StartNow()
                    .Build();

                await schedule.ScheduleJob(job, trigger);
            });

            Console.ReadKey();
        }
    }
}
