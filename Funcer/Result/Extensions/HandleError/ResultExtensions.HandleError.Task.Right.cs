using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> HandleError(this Result result, string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
    {
        if (result.IsSuccess) return result;
        
        var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
        var handledErrors = errorLookup[true].ToList();
        if (!handledErrors.Any()) return result;
        
        await onError(handledErrors);
            
        var remainingErrors = errorLookup[false].ToList();
        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
    
    public static async Task<Result> HandleError(this Result result, string errorType, Func<Task> onError)
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