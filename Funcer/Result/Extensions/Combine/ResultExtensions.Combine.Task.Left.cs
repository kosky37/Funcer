using System.Runtime.CompilerServices;
using Funcer.Helpers;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(IEnumerable<Task<Result>> resultTasks)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result> Combine(bool parallel = true)
        {
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
    
    extension(IEnumerable<Task<IResult>> resultTasks)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result> Combine(bool parallel = true)
        {
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
}

