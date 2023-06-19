using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Resolve_Task
{
    public static async Task Resolve(this Task<Result> resultTask, Func<Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Func<Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve(this Task<Result> resultTask, Func<Task> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Func<Task> onSuccess, Action onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action<IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Task<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, TReturnValue onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
}