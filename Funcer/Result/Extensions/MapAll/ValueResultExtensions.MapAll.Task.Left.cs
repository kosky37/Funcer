namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValueList, TValue>(Task<Result<TValueList>> resultTask)
        where TValueList : IEnumerable<TValue>
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

