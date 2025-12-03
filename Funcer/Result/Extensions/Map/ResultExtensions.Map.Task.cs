namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result<TValue>> Map<TValue>(Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }

        public async Task<Result<TValue>> Map<TValue>(Func<Task<TValue>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }
    }
}