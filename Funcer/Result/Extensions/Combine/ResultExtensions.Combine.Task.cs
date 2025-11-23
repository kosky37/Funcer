namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Combine(this Task<IEnumerable<IResult>> resultsTask)
    {
        var results = await resultsTask;
        return results.Combine();
    }
    
    public static async Task<Result> Combine(this Task<IEnumerable<Result>> resultsTask)
    {
        var results = await resultsTask;
        return results.Combine();
    }
}

