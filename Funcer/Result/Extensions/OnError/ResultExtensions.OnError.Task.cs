using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result> OnError(string errorType, Func<Task> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result> OnError(string errorType, Func<Task<Result>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }
    }
}

