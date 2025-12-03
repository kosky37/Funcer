namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Tap(Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Func<Task> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Func<TValue, Task> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<Task<TValue2>> next)
        {
            var result = await resultTask;
            return await result.Tap(next);
        }
    }
}