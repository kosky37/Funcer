namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<IEnumerable<Task<Result<TValue>>>> resultTasksTask)
    {
        public async Task<Result<IEnumerable<TValue>>> Combine()
        {
            var resultTasks = await resultTasksTask;
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
}

