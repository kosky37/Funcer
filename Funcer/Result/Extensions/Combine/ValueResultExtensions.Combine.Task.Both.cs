using System.Runtime.CompilerServices;
using Funcer.Helpers;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> Combine(bool parallel = true)
        {
            var resultTasks = await resultTasksTask;
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
}

