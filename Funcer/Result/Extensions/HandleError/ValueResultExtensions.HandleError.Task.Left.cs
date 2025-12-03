using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result<TValue>> HandleError(string errorType, Func<TValue> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result<TValue>> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Result<TValue>> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

        public async Task<Result<TValue>> HandleError(string errorType, Func<Result<TValue>> onError)
        {
            var result = await resultTask;

            return result.HandleError(errorType, onError);
        }

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