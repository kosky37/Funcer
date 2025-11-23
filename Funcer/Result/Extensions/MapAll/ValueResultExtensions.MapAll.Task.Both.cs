namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Result<TMappedValue>> mapper)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, TMappedValue> mapper)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task<Result<TMappedValue>>> mapper)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.MapAll(mapper);
    }
    
    public static async Task<Result<IEnumerable<TMappedValue>>> MapAll<TValue, TMappedValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task<TMappedValue>> mapper)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.MapAll(mapper);
    }
}

