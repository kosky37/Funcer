namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<IEnumerable<Result<TValue>>> resultsTask)
    {
        public async Task<Result<IEnumerable<TValue>>> Combine()
        {
            var results = await resultsTask;
            return results.Combine();
        }
    }
}

