using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> onSuccess, Action onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve<TValue>(this Task<Result<TValue>> resultTask, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
    {
        var result = await resultTask;

        await result.Resolve(onSuccess, onFailure);
    }
    

    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Task<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, TReturnValue onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        var result = await resultTask;

        return await result.Resolve(onSuccess, onFailure);
    }
}