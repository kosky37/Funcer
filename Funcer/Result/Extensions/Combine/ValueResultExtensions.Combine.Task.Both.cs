namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> Combine<TValue>(this Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
}

