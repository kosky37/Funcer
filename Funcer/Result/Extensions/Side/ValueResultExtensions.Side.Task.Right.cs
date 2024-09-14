using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Side<TValue>(this Result<TValue> result, Func<Task<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue>> Side<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next(result.Value);

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Result<TValue1> result, Func<Task<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next(result.Value);

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}