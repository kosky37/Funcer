namespace Funcer;

//TODO: add tests
//TODO: add Task and ValueTask variants
public static partial class ResultExtensions
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
    
    public static TValue Resolve<TValue>(this Result result, Func<TValue> onSuccess, Func<IList<Error>, TValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess();
    }
    
    public static TValue Resolve<TValue>(this Result result, TValue onSuccess, Func<IList<Error>, TValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : onSuccess;
    }
    
    public static TValue Resolve<TValue>(this Result result, TValue onSuccess, TValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess;
    }
    
    public static TValue Resolve<TValue>(this Result result, Func<TValue> onSuccess, TValue onFailure)
    {
        return result.IsFailure ? onFailure : onSuccess();
    }
}