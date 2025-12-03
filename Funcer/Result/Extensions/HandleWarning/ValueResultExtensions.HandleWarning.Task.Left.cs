using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> HandleWarning(string errorType, Action onWarning)
        {
            var result = await resultTask;

            return result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result<TValue>> HandleWarning(string errorType, Action<IEnumerable<WarningMessage>> onWarning)
        {
            var result = await resultTask;

            return result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result<TValue>> HandleWarning(string errorType, Action<IEnumerable<WarningMessage>, TValue> onWarning)
        {
            var result = await resultTask;

            return result.HandleWarning(errorType, onWarning);
        }
    }
}