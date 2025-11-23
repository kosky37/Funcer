namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Result<TMappedValue>> mapper)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, TMappedValue> mapper)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task<Result<TMappedValue>>> mapper)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this IEnumerable<Task<Result<TValue>>> resultTasks, Func<TValue, Task<TMappedValue>> mapper)
    {
        var results = await Task.WhenAll(resultTasks);
        return await results.MapAll(mapper);
    }
}

