namespace Funcer;

public static class ResultExtensions_Tap
{
    public static Result Tap(this Result result, Func<Result> next)
    {
        return result.IsFailure ? result : next();
    }
    
    public static Result Tap<TValue>(this Result result, Func<Result<TValue>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success();
    }
    
    public static Result Tap(this Result result, Action next)
    {
        if (result.IsSuccess) next();

        return result;
    }
    
    public static Result Tap<TValue>(this Result result, Func<TValue> next)
    {
        if (result.IsFailure) return result;
        next();
        
        return Result.Success();
    }
}