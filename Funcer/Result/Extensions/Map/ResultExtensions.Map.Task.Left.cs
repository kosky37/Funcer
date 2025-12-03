namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result<TValue>> Map<TValue>(Func<Result<TValue>> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }

        public async Task<Result<TValue>> Map<TValue>(Func<TValue> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }
    }
}