using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Resolve_ValueTask_Left
{
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        result.Resolve(onSuccess, onFailure);
    }

    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, TReturnValue onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return result.Resolve(onSuccess, onFailure);
    }
}