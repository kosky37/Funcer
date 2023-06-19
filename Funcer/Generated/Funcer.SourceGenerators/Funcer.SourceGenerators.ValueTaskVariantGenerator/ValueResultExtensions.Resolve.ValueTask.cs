using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Resolve_ValueTask
{
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    

    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, ValueTask<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, ValueTask<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, TReturnValue onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
}