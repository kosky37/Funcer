namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_TapIf_Task_Left
{
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Action next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Action next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, bool condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask,  Func<TValue1, bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, bool condition, Func<TValue2> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<bool> condition, Func<TValue2> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, bool> condition, Func<TValue2> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
}