namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Tap(Func<Result> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result> Tap<TValue>(Func<Result<TValue>> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result> Tap(Action next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result> Tap<TValue>(Func<TValue> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }
    }
}