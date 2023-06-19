using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Side_ValueTask_Right
{
    public static async ValueTask<Result> Side(this Result result, Func<ValueTask<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result> Side<TValue>(this Result result, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}