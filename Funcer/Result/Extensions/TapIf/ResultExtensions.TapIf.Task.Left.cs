namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> TapIf(bool condition, Func<Result> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(Func<bool> condition, Func<Result> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(bool condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(Func<bool> condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(bool condition, Action next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf(Func<bool> condition, Action next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(bool condition, Func<TValue> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result> TapIf<TValue>(Func<bool> condition, Func<TValue> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }
    }
}