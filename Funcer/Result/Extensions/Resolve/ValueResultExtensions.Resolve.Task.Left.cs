using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task Resolve(Action<TValue> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;

            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;

            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<TValue> onSuccess, Action onFailure)
        {
            var result = await resultTask;

            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action onFailure)
        {
            var result = await resultTask;

            result.Resolve(onSuccess, onFailure);
        }
    }

    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, TReturnValue onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return result.Resolve(onSuccess, onFailure);
    }
}