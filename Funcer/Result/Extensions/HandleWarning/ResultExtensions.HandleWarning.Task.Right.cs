using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> HandleWarning(string errorType, Func<IEnumerable<WarningMessage>, Task> onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            await onWarning(handledWarnings);

            return result.WithoutWarnings(handledWarnings);
        }

        public async Task<Result> HandleWarning(string errorType, Func<Task> onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            await onWarning();

            return result.WithoutWarnings(handledWarnings);
        }
    }
}