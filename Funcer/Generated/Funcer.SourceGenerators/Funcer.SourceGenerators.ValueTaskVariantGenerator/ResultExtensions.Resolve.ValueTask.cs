using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Resolve_ValueTask
{
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<ValueTask> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action<IEnumerable<WarningMessage>> onSuccess, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, ValueTask<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, ValueTask<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, TReturnValue onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        var result = await resultValueTask;

        return await result.Resolve(onSuccess, onFailure);
    }
}