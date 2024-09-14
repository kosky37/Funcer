using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Side(this Result result, Func<Result> next)
    {
        if (result.IsFailure) return result;

        var nextResult = next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static Result Side<TValue>(this Result result, Func<Result<TValue>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = next();

        return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}