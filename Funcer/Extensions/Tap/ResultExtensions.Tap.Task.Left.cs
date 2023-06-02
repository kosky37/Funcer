using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Tap_Task_Left
{
    public static async Task<Result> Tap(this Task<Result> resultTask, Func<Result> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result> Tap<TValue>(this Task<Result> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result> Tap(this Task<Result> resultTask, Action next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result> Tap<TValue>(this Task<Result> resultTask, Func<TValue> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
}