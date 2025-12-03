namespace Funcer;

public static partial class ResultExtensions
{
    extension(IEnumerable<Task<Result>> resultTasks)
    {
        public async Task<Result> Combine()
        {
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
    
    extension(IEnumerable<Task<IResult>> resultTasks)
    {
        public async Task<Result> Combine()
        {
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
}

