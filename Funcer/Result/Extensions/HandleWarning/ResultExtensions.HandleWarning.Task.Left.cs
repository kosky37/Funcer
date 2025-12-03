using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> HandleWarning(string errorType, Action<IEnumerable<WarningMessage>> onWarning)
        {
            var result = await resultTask;

            return result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result> HandleWarning(string errorType, Action onWarning)
        {
            var result = await resultTask;

            return result.HandleWarning(errorType, onWarning);
        }
    }
}