using System.Runtime.CompilerServices;
using Funcer.Helpers;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<IEnumerable<TValue>> result)
    {
        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task<Result>> next, bool parallel = true)
        {
            if (result.IsFailure) return result;

            var tapResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
            var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue>>.Failure(errors);
            }

            if (tapResults.Length == 0)
            {
                return result;
            }

            return result.WithContext(tapResults[0]);
        }

        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task> next, bool parallel = true)
        {
            if (result.IsFailure) return result;
            
            if (parallel)
            {
                await Task.WhenAll(result.Value.Select(next));
            }
            else
            {
                await result.Value.Select(next)
                    .ExecuteSequentially();
            }

            return result;
        }

        [OverloadResolutionPriority(1)]
        public async Task<Result<IEnumerable<TValue>>> TapAll<TValue2>(Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
        {
            if (result.IsFailure) return result;

            var tapResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
            var errors = tapResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

            if (errors.Count is not 0)
            {
                return Result<IEnumerable<TValue>>.Failure(errors);
            }

            if (tapResults.Length == 0)
            {
                return result;
            }

            return result.WithContext(tapResults[0]);
        }
    }
}

