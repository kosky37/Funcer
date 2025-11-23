namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Result> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Action<TValue> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Action tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Result<TValue2>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task<Result>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<Task> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task<Result<TValue2>>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, TValue2> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue2> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<Task<TValue2>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task<TValue2>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<Result<TValue>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<Task<Result<TValue>>> tap)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
}

