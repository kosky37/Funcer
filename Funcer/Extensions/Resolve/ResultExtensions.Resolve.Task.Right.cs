using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Resolve_Task_Right
{
    public static async Task Resolve(this Result result, Func<Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess();
    }
    
    public static async Task Resolve(this Result result, Func<Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess();
    }
    
    public static async Task Resolve(this Result result, Action onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess();
    }
    
    
    public static async Task Resolve(this Result result, Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess(result.Warnings);
    }
    
    public static async Task Resolve(this Result result, Func<IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess(result.Warnings);
    }
    
    public static async Task Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess(result.Warnings);
    }
    
    
    public static async Task Resolve(this Result result, Func<Task> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess();
    }
    
    public static async Task Resolve(this Result result, Func<Task> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess();
    }
    
    public static async Task Resolve(this Result result, Action onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess();
    }
    
    
    public static async Task Resolve(this Result result, Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess(result.Warnings);
    }
    
    public static async Task Resolve(this Result result, Func<IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess(result.Warnings);
    }
    
    public static async Task Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess(result.Warnings);
    }
    
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess();
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess();
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess();
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Warnings);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess;
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Task<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess;
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess();
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess();
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess();
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Warnings);
    }
}