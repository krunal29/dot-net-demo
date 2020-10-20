using System;
using System.Linq.Expressions;
using DotNetDemo.Business.Interfaces.Services.Background;
using Hangfire;

namespace DotNetDemo.Business.Services.Background
{
    public class BackgroundService : IBackgroundService
    {
        public void EnqueueJob<TJobs>(Expression<Action<TJobs>> job) where TJobs : IBackgroundJobs
        {
            BackgroundJob.Enqueue(job);
        }

        public void ScheduleJob<TJobs>(Expression<Action<TJobs>> job, DateTimeOffset date) where TJobs : IBackgroundJobs
        {
            BackgroundJob.Schedule(job, date);
        }
    }
}
