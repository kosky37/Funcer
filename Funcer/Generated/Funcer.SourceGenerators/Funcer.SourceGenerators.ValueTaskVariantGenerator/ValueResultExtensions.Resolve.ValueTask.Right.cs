using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Resolve_ValueTask_Right
{
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess(result.Value!);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess(result.Value!);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess(result.Value!);
    }
    
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess(result.Value!, result.Warnings);
    }
    
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess(result.Value!);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, ValueTask> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess(result.Value!);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess(result.Value!);
    }
    
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess(result.Value!, result.Warnings);
    }
    

    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Value!);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Value!);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Value!);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Value!, result.Warnings);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess;
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, ValueTask<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, ValueTask<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess;
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Value!);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Value!);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Value!);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Value!, result.Warnings);
    }
}