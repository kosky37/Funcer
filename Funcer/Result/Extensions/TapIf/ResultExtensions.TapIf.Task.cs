namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> TapIf(bool condition, Func<Task<Result>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(Func<bool> condition, Func<Task<Result>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(bool condition, Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(Func<bool> condition, Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(bool condition, Func<Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(Func<bool> condition, Func<Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(bool condition, Func<Task<TValue>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(Func<bool> condition, Func<Task<TValue>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }
    }
}