using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> HandleWarning(string errorType, Action onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            onWarning();

            return result.WithoutWarnings(handledWarnings);
        }

        public Result<TValue> HandleWarning(string errorType, Action<IEnumerable<WarningMessage>> onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            onWarning(handledWarnings);

            return result.WithoutWarnings(handledWarnings);
        }

        public Result<TValue> HandleWarning(string errorType, Action<IEnumerable<WarningMessage>, TValue> onWarning)
        {
            if (result.IsFailure) return result;
        
            var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

            if (handledWarnings.Count == 0) return result;

            onWarning(handledWarnings, result.Value);

            return result.WithoutWarnings(handledWarnings);
        }
    }
}