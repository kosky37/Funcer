using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<Task<TValue>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning();

        return result.WithoutWarnings(handledWarnings);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<WarningMessage>, Task<TValue>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning(handledWarnings);

        return result.WithoutWarnings(handledWarnings);
    }
    
    public static async Task<Result<TValue>> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<WarningMessage>, TValue, Task<TValue>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning(handledWarnings, result.Value);

        return result.WithoutWarnings(handledWarnings);
    }
}