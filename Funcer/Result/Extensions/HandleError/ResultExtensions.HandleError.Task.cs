using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
        {
            var result = await resultTask;

            return await result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Func<Task> onError)
        {
            var result = await resultTask;

            return await result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError)
        {
            var result = await resultTask;

            return await result.HandleError(errorType, onError);
        }

        public async Task<Result> HandleError(string errorType, Func<Task<Result>> onError)
        {
            var result = await resultTask;

            return await result.HandleError(errorType, onError);
        }
    }
}