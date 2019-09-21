using Quartz;
using System;
using System.Threading.Tasks;

namespace LearningQuartz
{
    class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("simple job executed");

            await Task.CompletedTask;
        }
    }
}
