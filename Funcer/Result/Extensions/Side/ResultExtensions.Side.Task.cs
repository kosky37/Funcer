namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Side(Func<Task<Result>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }

        public async Task<Result> Side<TValue>(Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }
    }
}