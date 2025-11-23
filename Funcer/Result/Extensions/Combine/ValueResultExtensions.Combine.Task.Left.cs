namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> Combine<TValue>(this IEnumerable<Task<Result<TValue>>> resultTasks)
    {
        var results = await Task.WhenAll(resultTasks);
        return results.Combine();
    }
}

