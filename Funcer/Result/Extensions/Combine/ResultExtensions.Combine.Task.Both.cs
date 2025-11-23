namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> resultTasksTask)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
    
    public static async Task<Result> Combine(this Task<IEnumerable<Task<IResult>>> resultTasksTask)
    {
        var resultTasks = await resultTasksTask;
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
}

