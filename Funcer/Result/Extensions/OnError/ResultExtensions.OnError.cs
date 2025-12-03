using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static Result OnError(this Result result, string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
        
        var nextResult = onError(matchedErrors);
        
        // Preserve original result, but combine errors if nextResult has errors
        if (nextResult.IsFailure)
        {
            var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
            return Result.Failure(allErrors).WithContext(nextResult);
        }
        
        // Preserve original result unchanged, but preserve warnings from nextResult
        return result.WithContext(nextResult);
    }
    
    public static Result OnError(this Result result, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
        
        onError(matchedErrors);
        
        // Preserve original result unchanged
        return result;
    }
    
    public static Result OnError(this Result result, string errorType, Func<Result> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
            
        var nextResult = onError();
        
        // Preserve original result, but combine errors if nextResult has errors
        if (nextResult.IsFailure)
        {
            var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
            return Result.Failure(allErrors).WithContext(nextResult);
        }
        
        // Preserve original result unchanged, but preserve warnings from nextResult
        return result.WithContext(nextResult);
    }
    
    public static Result OnError(this Result result, string errorType, Action onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var matchedErrors = errorLookup[true].ToList();
        if (matchedErrors.Count == 0) return result;
            
        onError();

        // Preserve original result unchanged
        return result;
    }
}

