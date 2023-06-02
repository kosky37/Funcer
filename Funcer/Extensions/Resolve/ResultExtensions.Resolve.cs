namespace Funcer;

//TODO: add tests
public static class ResultExtensions_Resolve
{
    public static void Resolve(this Result result, Action onSuccess, Action<IList<Error>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else onSuccess();
    }
    
    public static void Resolve(this Result result, Action onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else onSuccess();
    }
    
    public static void Resolve(this Result result, Action<IList<Error>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
    }
    
    public static void Resolve(this Result result, Action onFailure)
    {
        if (result.IsFailure) onFailure();
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, Func<TReturnValue> onSuccess, Func<IList<Error>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess();
    }
    
    public static TReturnValue Resolve<TReturnValue>(this Result result, TReturnValue onSuccess, Func<IList<Error>, TReturnValue> onFailure)
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
}