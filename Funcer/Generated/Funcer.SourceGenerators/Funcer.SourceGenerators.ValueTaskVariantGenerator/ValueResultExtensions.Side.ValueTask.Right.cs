using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Side_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> Side<TValue>(this Result<TValue> result, Func<ValueTask<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue1>> Side<TValue1, TValue2>(this Result<TValue1> result, Func<ValueTask<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}