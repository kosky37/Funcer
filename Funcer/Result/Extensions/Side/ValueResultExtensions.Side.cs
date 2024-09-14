using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> Side<TValue>(this Result<TValue> result, Func<Result> next)
    {
        if (result.IsFailure) return result;

        var nextResult = next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> Side<TValue1, TValue2>(this Result<TValue1> result, Func<Result<TValue2>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}