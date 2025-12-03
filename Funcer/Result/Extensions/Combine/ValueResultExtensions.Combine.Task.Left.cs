namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(IEnumerable<Task<Result<TValue>>> resultTasks)
    {
        public async Task<Result<IEnumerable<TValue>>> Combine()
        {
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
}

