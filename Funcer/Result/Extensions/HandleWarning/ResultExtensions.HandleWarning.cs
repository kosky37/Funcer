using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static Result HandleWarning(this Result result, string errorType, Action<IEnumerable<WarningMessage>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning(handledWarnings);

        return result.WithoutWarnings(handledWarnings);
    }
    
    public static Result HandleWarning(this Result result, string errorType, Action onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        onWarning();

        return result.WithoutWarnings(handledWarnings);
    }
}