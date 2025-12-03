namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Side(Func<Result> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }

        public async Task<Result> Side<TValue>(Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }
    }
}