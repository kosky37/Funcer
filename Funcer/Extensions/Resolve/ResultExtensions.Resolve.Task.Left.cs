using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Resolve_Task_Left
{
    public static async Task Resolve(this Task<Result> resultTask, Action onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action<IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action onSuccess, Action onFailure)
    {
        var result = await resultTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task Resolve(this Task<Result> resultTask, Action<IEnumerable<WarningMessage>> onSuccess, Action onFailure)
    {
        var result = await resultTask;
        
        result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, TReturnValue onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue>(this Task<Result> resultTask, Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
    {
        var result = await resultTask;
        
        return result.Resolve(onSuccess, onFailure);
    }
}