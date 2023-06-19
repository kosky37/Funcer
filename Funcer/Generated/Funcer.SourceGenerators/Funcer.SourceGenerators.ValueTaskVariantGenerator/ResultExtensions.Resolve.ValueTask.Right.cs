using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Resolve_ValueTask_Right
{
    public static async ValueTask Resolve(this Result result, Func<ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess();
    }
    
    public static async ValueTask Resolve(this Result result, Func<ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess();
    }
    
    public static async ValueTask Resolve(this Result result, Action onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess();
    }
    
    
    public static async ValueTask Resolve(this Result result, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else await onSuccess(result.Warnings);
    }
    
    public static async ValueTask Resolve(this Result result, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else await onSuccess(result.Warnings);
    }
    
    public static async ValueTask Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        else onSuccess(result.Warnings);
    }
    
    
    public static async ValueTask Resolve(this Result result, Func<ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess();
    }
    
    public static async ValueTask Resolve(this Result result, Func<ValueTask> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess();
    }
    
    public static async ValueTask Resolve(this Result result, Action onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess();
    }
    
    
    public static async ValueTask Resolve(this Result result, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else await onSuccess(result.Warnings);
    }
    
    public static async ValueTask Resolve(this Result result, Func<IEnumerable<WarningMessage>, ValueTask> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else await onSuccess(result.Warnings);
    }
    
    public static async ValueTask Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        else onSuccess(result.Warnings);
    }
    
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess();
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess();
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess();
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Warnings);
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, ValueTask<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, ValueTask<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess;
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, ValueTask<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, ValueTask<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess;
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess;
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess();
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess();
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess();
    }
    
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, ValueTask<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Warnings);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, ValueTask<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Warnings);
    }
}