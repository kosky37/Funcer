namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Result<TMappedValue>> mapper)
    {
        var results = await resultsTask;
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, TMappedValue> mapper)
    {
        var results = await resultsTask;
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task<Result<TMappedValue>>> mapper)
    {
        var results = await resultsTask;
        return await results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Result<TValue>>> resultsTask, Func<TValue, Task<TMappedValue>> mapper)
    {
        var results = await resultsTask;
        return await results.MapAll(mapper);
    }
}

