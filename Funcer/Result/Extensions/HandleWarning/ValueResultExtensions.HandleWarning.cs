using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<WarningMessage>, TValue> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning(handledWarnings);

        return result.WithoutWarnings(handledWarnings);
    }
    
    public static Result<TValue> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<TValue> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning();

        return result.WithoutWarnings(handledWarnings);
    }
}