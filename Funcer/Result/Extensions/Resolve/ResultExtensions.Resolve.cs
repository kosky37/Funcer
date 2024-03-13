using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static void Resolve(this Result result, Action onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess();
    }
    
    public static void Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess(result.Warnings);
    }
    
    public static void Resolve(this Result result, Action onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess();
    }
    
    public static void Resolve(this Result result, Action<IEnumerable<WarningMessage>> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess(result.Warnings);
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess();
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess(result.Warnings);
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess;
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess;
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess();
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess(result.Warnings);
    }
}