using System.Runtime.CompilerServices;
using Funcer.Helpers;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(IEnumerable<Task<Result<TValue>>> resultTasks)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> Combine(bool parallel = true)
        {
            var results = parallel ? await Task.WhenAll(resultTasks) : await resultTasks.ExecuteSequentially();
            return results.Combine();
        }
    }
}

