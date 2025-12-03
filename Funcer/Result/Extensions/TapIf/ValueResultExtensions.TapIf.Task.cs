namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> TapIf(bool condition, Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<TValue, Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<TValue, Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<TValue, Task> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<Task<TValue2>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<Task<TValue2>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> next)
        {
            var result = await resultTask;

            return await result.TapIf(condition, next);
        }
    }
}