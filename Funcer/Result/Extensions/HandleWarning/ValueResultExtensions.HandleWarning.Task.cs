using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> HandleWarning(string errorType, Func<Task<TValue>> onWarning)
        {
            var result = await resultTask;

            return await result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result<TValue>> HandleWarning(string errorType, Func<IEnumerable<WarningMessage>, Task<TValue>> onWarning)
        {
            var result = await resultTask;

            return await result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result<TValue>> HandleWarning(string errorType, Func<IEnumerable<WarningMessage>, TValue, Task<TValue>> onWarning)
        {
            var result = await resultTask;

            return await result.HandleWarning(errorType, onWarning);
        }
    }
}