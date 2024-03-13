using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Side(this Result result, Func<Task<Result>> next)
    {
        if (result.IsFailure) return result;

        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
    
    public static async Task<Result> Side<TValue>(this Result result, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        
        var nextResult = await next();

        return nextResult.IsFailure ? result.Warn(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
    }
}