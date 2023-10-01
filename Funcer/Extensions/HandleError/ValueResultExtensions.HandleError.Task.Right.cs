using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleError_Task_Right
{
    public static async Task<Result<TValue>> HandleError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
        
        var newValue = await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static async Task<Result<TValue>> HandleError<TValue>(this Result<TValue> result, string errorType, Func<Task<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
            
        var newValue = await onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static async Task<Result> HandleError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return Result.Failure(result.Errors);
        
        await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
    
    public static async Task<Result> HandleError<TValue>(this Result<TValue> result, string errorType, Func<Task> onError)
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