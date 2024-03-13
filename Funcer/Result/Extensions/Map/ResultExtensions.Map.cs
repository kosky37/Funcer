namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Map(this Result result, Func<Result> next)
    {
        return result.IsFailure ? result : next().WithContext(result);
    }
    
    public static Result<TValue> Map<TValue>(this Result result, Func<Result<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : next().WithContext(result);
    }
    
    public static Result Map(this Result result, Action next)
    {
        if (result.IsSuccess) next();

        return result;
    }
    
    public static Result<TValue> Map<TValue>(this Result result, Func<TValue> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(next()).WithContext(result);
    }
}