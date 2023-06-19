using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleWarning
{
    public static Result<TValue> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<WarningMessage>, TValue> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning(handledWarnings);

        foreach (var warning in handledWarnings)
        {
            result.RemoveWarning(warning);
        }

        return result;
    }
    
    public static Result<TValue> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<TValue> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning();

        foreach (var warning in handledWarnings)
        {
            result.RemoveWarning(warning);
        }

        return result;
    }
}