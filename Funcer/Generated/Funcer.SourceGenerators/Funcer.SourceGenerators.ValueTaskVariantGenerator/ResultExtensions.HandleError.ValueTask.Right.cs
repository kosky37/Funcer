using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_HandleError_ValueTask_Right
{
    public static async ValueTask<Result> HandleError(this Result result, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
        
        await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
    
    public static async ValueTask<Result> HandleError(this Result result, string errorType, Func<ValueTask> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
            
        await onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}