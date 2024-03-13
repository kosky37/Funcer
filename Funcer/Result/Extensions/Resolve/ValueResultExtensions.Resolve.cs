using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess(result.Value!);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess(result.Value!, result.Warnings);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess(result.Value!);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess(result.Value!, result.Warnings);
    }

    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess(result.Value!);
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess(result.Value!, result.Warnings);
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess;
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess;
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess(result.Value!);
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess(result.Value!, result.Warnings);
    }
}