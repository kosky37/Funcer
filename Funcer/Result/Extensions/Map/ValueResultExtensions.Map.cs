namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> Map(Func<Result<TValue>> next)
        {
            return result.IsFailure ? result : next().WithContext(result);
        }

        public Result<TValue2> Map<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : next(result.Value!).WithContext(result);
        }

        public Result<TValue2> Map<TValue2>(Func<TValue2> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next()).WithContext(result);
        }

        public Result<TValue2> Map<TValue2>(Func<TValue, TValue2> next)
        {
            return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next(result.Value!)).WithContext(result);
        }
    }
}