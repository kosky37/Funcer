using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Side_Task_Right
{
    public static async Task<Result<TValue>> Side<TValue>(this Result<TValue> result, Func<Task<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Result<TValue1> result, Func<Task<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}