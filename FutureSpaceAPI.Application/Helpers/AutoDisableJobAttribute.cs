using Hangfire;
using Hangfire.Common;
using Hangfire.States;
using Hangfire.Storage;

namespace FutureSpaceAPI.Application.Helpers
{
    public class AutoDisableJobAttribute : JobFilterAttribute, IApplyStateFilter
    {
        private readonly int maxExecutions = 20;
        public AutoDisableJobAttribute()
        {
        }

        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            if (LauncherServiceExecutionCount.ExecutionCount >= maxExecutions)
            {
                RecurringJob.RemoveIfExists("ILauncherService.Execute");
            }
        }
    }
}
