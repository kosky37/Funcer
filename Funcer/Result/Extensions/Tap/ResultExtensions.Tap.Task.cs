namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Tap(Func<Task<Result>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result> Tap<TValue>(Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result> Tap(Func<Task> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result> Tap<TValue>(Func<Task<TValue>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }
    }
}