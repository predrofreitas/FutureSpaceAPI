using FutureSpaceAPI.Application.Helpers;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;

namespace FutureSpaceAPI.Hangfire
{
    public class AutoDisableJobAttribute : JobFilterAttribute, IApplyStateFilter
    {
        private readonly int maxExecutions = 1;

        public AutoDisableJobAttribute()
        {
        }

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            if (LauncherServiceExecutionCount.ExecutionCount >= maxExecutions)
            {
                context.JobExpirationTimeout = TimeSpan.Zero;
            }
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }
    }
}
