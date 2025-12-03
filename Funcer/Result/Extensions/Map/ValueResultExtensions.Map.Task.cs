namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Map(Func<Task<Result<TValue>>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<Task<TValue2>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, Task<TValue2>> next)
        {
            var result = await resultTask;
            return await result.Map(next);
        }
    }
}