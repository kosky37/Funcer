namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Result> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Action<TValue> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Action tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Result<TValue2>> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task<Result>> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<Task> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task<Result<TValue2>>> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, TValue2> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue2> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<Task<TValue2>> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task<TValue2>> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<Result<TValue>> tap)
    {
        var results = await resultsTask;
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<Task<Result<TValue>>> tap)
    {
        var results = await resultsTask;
        return await results.TapAll(tap);
    }
}

