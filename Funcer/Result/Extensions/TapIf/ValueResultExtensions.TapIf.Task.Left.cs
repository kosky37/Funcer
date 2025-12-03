namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> TapIf(bool condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<TValue, Result> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<TValue, Result> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<TValue, Result> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Action next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Action next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Action next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Action<TValue> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Action<TValue> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Action<TValue> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<TValue2> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<TValue2> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue2> next)
        {
            var result = await resultTask;

            return result.TapIf(condition, next);
        }
    }
}