using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> OnError(string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<TValue> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Result<TValue>> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError(string errorType, Func<Result<TValue>> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }
    }
}

