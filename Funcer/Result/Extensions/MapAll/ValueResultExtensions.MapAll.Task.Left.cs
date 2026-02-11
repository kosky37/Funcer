namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<IEnumerable<TValue>>> resultTask)
    {
        public async Task<Result<IEnumerable<TValue2>>> MapAll<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;
            return result.MapAll(next);
        }

        public async Task<Result<IEnumerable<TValue2>>> MapAll<TValue2>(Func<TValue, TValue2> next)
        {
            var result = await resultTask;
            return result.MapAll(next);
        }
    }
}

