using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> HandleWarning(this Result result, string errorType, Func<IEnumerable<WarningMessage>, Task> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning(handledWarnings);

        return result.WithoutWarnings(handledWarnings);
    }
    
    public static async Task<Result> HandleWarning(this Result result, string errorType, Func<Task> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning();

        return result.WithoutWarnings(handledWarnings);
    }
}