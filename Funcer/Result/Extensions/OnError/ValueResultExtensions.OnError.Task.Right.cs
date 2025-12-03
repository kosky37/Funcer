using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> OnError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
        
        // Execute the function but ignore the return value - we preserve the original result
        await onError(matchedErrors);
        
        // Preserve original result unchanged
        return result;
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Result<TValue> result, string errorType, Func<Task<TValue>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
            
        // Execute the function but ignore the return value - we preserve the original result
        await onError();

        // Preserve original result unchanged
        return result;
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result<TValue>>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
        
        var nextResult = await onError(matchedErrors);
        
        // Preserve original result, but combine errors if nextResult has errors
        if (nextResult.IsFailure)
        {
            var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
            return Result<TValue>.Failure(allErrors).WithContext(nextResult);
        }
        
        // Preserve original result unchanged, but preserve warnings from nextResult
        return result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue>> OnError<TValue>(this Result<TValue> result, string errorType, Func<Task<Result<TValue>>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
            
        var nextResult = await onError();
        
        // Preserve original result, but combine errors if nextResult has errors
        if (nextResult.IsFailure)
        {
            var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
            return Result<TValue>.Failure(allErrors).WithContext(nextResult);
        }
        
        // Preserve original result unchanged, but preserve warnings from nextResult
        return result.WithContext(nextResult);
    }
    
    public static async Task<Result> OnError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return Result.Failure(result.Errors);
        
        await onError(matchedErrors);
            
        // Preserve original result's errors
        return Result.Failure(result.Errors);
    }
    
    public static async Task<Result> OnError<TValue>(this Result<TValue> result, string errorType, Func<Task> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return Result.Failure(result.Errors);
            
        await onError();

        // Preserve original result's errors
        return Result.Failure(result.Errors);
    }
    
    public static async Task<Result> OnError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return Result.Failure(result.Errors);
        
        var nextResult = await onError(matchedErrors);
        
        // Preserve original result's errors, but combine errors if nextResult has errors
        var allErrors = nextResult.IsFailure 
            ? result.Errors.Concat(nextResult.Errors).ToList()
            : result.Errors.ToList();
        
        return Result.Failure(allErrors).WithContext(nextResult);
    }
    
    public static async Task<Result> OnError<TValue>(this Result<TValue> result, string errorType, Func<Task<Result>> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return Result.Failure(result.Errors);
            
        var nextResult = await onError();
        
        // Preserve original result's errors, but combine errors if nextResult has errors
        var allErrors = nextResult.IsFailure 
            ? result.Errors.Concat(nextResult.Errors).ToList()
            : result.Errors.ToList();
        
        return Result.Failure(allErrors).WithContext(nextResult);
    }
}

