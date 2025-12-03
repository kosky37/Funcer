namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<IEnumerable<TValue>>> resultTask)
    {
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task<Result>> next)
        {
            var result = await resultTask;
            return await result.TapAll(next);
        }

        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Task> next)
        {
            var result = await resultTask;
            return await result.TapAll(next);
        }

        public async Task<Result<IEnumerable<TValue>>> TapAll<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            var result = await resultTask;
            return await result.TapAll(next);
        }
    }
}