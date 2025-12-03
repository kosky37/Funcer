namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Side(Func<Task<Result>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }

        public async Task<Result<TValue>> Side(Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<Task<Result<TValue2>>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;

            return await result.Side(next);
        }
    }
}