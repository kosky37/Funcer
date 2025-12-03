using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<Task<TValue>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result<TValue>>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<Task<Result<TValue>>> onError)
        {
            var result = await resultTask;
            return await result.OnError(errorType, onError);
        }
    }
}

