using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Map_Task_Left
{
    public static async Task<Result> Map(this Task<Result> resultTask, Func<Result> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result> Map(this Task<Result> resultTask, Action next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
}