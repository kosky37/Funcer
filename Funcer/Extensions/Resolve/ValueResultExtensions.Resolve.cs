namespace Funcer;

//TODO: add tests
public static class ValueResultExtensions_Resolve
{
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Action<IList<Error>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess(result.Value!);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess(result.Value!);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action<IList<Error>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
    }
    
    public static void Resolve<TValue>(this Result<TValue> result, Action onFailure)
    {
        if (result.IsFailure) onFailure();
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, Func<IList<Error>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess(result.Value!);
    }
    
    public static TReturnValue Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, Func<IList<Error>, TReturnValue> onFailure)
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
}