using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Resolve_ValueTask_Left
{
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action<IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action onSuccess, Action onFailure)
    {
        var result = await resultValueTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask Resolve(this ValueTask<Result> resultValueTask, Action<IEnumerable<WarningMessage>> onSuccess, Action onFailure)
    {
        var result = await resultValueTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, TReturnValue onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async ValueTask<TReturnValue> Resolve<TReturnValue>(this ValueTask<Result> resultValueTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultValueTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
}