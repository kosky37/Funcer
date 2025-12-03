using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> HandleError(string errorType, Action<IEnumerable<ErrorMessage>> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Action onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Func<Result> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }
    }
}