namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<IEnumerable<Task<Result>>> resultTasksTask)
    {
        public async Task<Result> Combine()
        {
            var resultTasks = await resultTasksTask;
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
    
    extension(Task<IEnumerable<Task<IResult>>> resultTasksTask)
    {
        public async Task<Result> Combine()
        {
            var resultTasks = await resultTasksTask;
            var results = await Task.WhenAll(resultTasks);
            return results.Combine();
        }
    }
}

