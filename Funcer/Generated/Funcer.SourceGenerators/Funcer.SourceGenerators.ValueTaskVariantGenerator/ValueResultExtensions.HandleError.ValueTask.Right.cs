using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleError_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
        
        var newValue = await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static async ValueTask<Result<TValue>> HandleError<TValue>(this Result<TValue> result, string errorType, Func<ValueTask<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
            
        var newValue = await onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, ValueTask> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return Result.Failure(result.Errors);
        
        await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
    
    public static async ValueTask<Result> HandleError<TValue>(this Result<TValue> result, string errorType, Func<ValueTask> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return Result.Failure(result.Errors);
            
        await onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}