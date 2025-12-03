using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> HandleWarning(string errorType, Func<IEnumerable<WarningMessage>, Task> onWarning)
        {
            var result = await resultTask;

            return await result.HandleWarning(errorType, onWarning);
        }

        public async Task<Result> HandleWarning(string errorType, Func<Task> onWarning)
        {
            var result = await resultTask;

            return await result.HandleWarning(errorType, onWarning);
        }
    }
}