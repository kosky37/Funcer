namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Result> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Action<TValue> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Action tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Result<TValue2>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task<Result>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<Task> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task<Result<TValue2>>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, TValue2> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue2> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<Task<TValue2>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<TValue, Task<TValue2>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<Result<TValue>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.TapAll(tap);
    }
    
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask, Func<Task<Result<TValue>>> tap)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return await results.TapAll(tap);
    }
}

