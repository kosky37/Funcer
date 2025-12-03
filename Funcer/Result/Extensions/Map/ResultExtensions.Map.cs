namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result<TValue> Map<TValue>(Func<Result<TValue>> next)
        {
            return result.IsFailure ? Result<TValue>.Failure(result.Errors) : next().WithContext(result);
        }

        public Result<TValue> Map<TValue>(Func<TValue> next)
        {
            return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(next()).WithContext(result);
        }
    }
}