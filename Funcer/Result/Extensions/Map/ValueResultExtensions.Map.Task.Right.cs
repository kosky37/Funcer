namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> Map(Func<Task<Result<TValue>>> next)
        {
            return result.IsFailure ? result : (await next()).WithContext(result);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : (await next(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<Task<TValue2>> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, Task<TValue2>> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next(result.Value!)).WithContext(result);
        }
    }
}