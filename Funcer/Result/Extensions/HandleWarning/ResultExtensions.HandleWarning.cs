using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result HandleWarning(string errorType, Action<IEnumerable<WarningMessage>> onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            onWarning(handledWarnings);

            return result.WithoutWarnings(handledWarnings);
        }

        public Result HandleWarning(string errorType, Action onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            onWarning();

            return result.WithoutWarnings(handledWarnings);
        }
    }
}