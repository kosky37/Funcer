using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> HandleError<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
        
        var newValue = onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static Result<TValue> HandleError<TValue>(this Result<TValue> result, string errorType, Func<TValue> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
            
        var newValue = onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
    }
    
    public static Result HandleError<TValue>(this Result<TValue> result, string errorType, Action<IEnumerable<ErrorMessage>> onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return Result.Failure(result.Errors);
        
        onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
    
    public static Result HandleError<TValue>(this Result<TValue> result, string errorType, Action onError)
    {
        if (result.IsSuccess) return Result.Success().WithContext(result);
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return Result.Failure(result.Errors);
            
        onError();

        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}