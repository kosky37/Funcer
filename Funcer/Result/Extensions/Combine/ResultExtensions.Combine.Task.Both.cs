using System.Runtime.CompilerServices;
using Funcer.Helpers;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<IEnumerable<Task<Result>>> resultTasksTask)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result> Combine(bool parallel = true)
        {
            var resultTasks = await resultTasksTask;
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
    
    extension(Task<IEnumerable<Task<IResult>>> resultTasksTask)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result> Combine(bool parallel = true)
        {
            var resultTasks = await resultTasksTask;
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
}

