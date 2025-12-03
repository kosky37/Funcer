namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result<TValue>> Map<TValue>(Func<Task<Result<TValue>>> next)
        {
            return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await next()).WithContext(result);
        }

        public async Task<Result<TValue>> Map<TValue>(Func<Task<TValue>> next)
        {
            return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
        }
    }
}