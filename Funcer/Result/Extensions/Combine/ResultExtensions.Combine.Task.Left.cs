namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Combine(this IEnumerable<Task<Result>> resultTasks)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
    
    public static async Task<Result> Combine(this IEnumerable<Task<IResult>> resultTasks)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
}

