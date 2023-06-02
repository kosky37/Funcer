using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Side
{
    public static Result<TValue> Side<TValue>(this Result<TValue> result, Func<Result> next)
    {
        if (result.IsFailure) return result;

        var nextResult = next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new Warning(error))) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> Side<TValue1, TValue2>(this Result<TValue1> result, Func<Result<TValue2>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new Warning(error))) : result.WithContext(nextResult);
    }
}