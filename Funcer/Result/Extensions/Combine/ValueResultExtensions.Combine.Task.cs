namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> Combine<TValue>(this Task<IEnumerable<Result<TValue>>> resultsTask)
    {
        var results = await resultsTask;
        return results.Combine();
    }
}

