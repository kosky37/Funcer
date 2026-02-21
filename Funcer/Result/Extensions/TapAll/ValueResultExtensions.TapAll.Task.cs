using System.Runtime.CompilerServices;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<IEnumerable<TValue>>> resultTask)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task<Result>> next, bool parallel = true)
        {
            var result = await resultTask;
            return await result.TapAll(next, parallel);
        }

        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task> next, bool parallel = true)
        {
            var result = await resultTask;
            return await result.TapAll(next, parallel);
        }

        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll<TValue2>(Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
        {
            var result = await resultTask;
            return await result.TapAll(next, parallel);
        }
    }
}