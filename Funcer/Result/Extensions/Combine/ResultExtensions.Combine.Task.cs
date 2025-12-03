namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<IEnumerable<IResult>> resultsTask)
    {
        public async Task<Result> Combine()
        {
            var results = await resultsTask;
            return results.Combine();
        }
    }
    
    extension(Task<IEnumerable<Result>> resultsTask)
    {
        public async Task<Result> Combine()
        {
            var results = await resultsTask;
            return results.Combine();
        }
    }
}

