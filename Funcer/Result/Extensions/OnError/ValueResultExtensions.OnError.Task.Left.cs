using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<IEnumerable<ErrorMessage>, TValue2> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<TValue2> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<IEnumerable<ErrorMessage>, Result<TValue2>> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<Result<TValue2>> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }
        
        public async Task<Result<TValue>> OnError(string errorType, Action onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }
        
        public async Task<Result<TValue>> OnError(string errorType, Action<IEnumerable<ErrorMessage>> onError)
        {
            var result = await resultTask;
            return result.OnError(errorType, onError);
        }
    }
}

