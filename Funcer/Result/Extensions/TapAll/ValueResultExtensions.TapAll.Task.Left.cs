namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<IEnumerable<TValue>>> resultTask)
    {
        public async Task<Result<IEnumerable<TValue>>> TapAll(Func<TValue, Result> next)
        {
            var result = await resultTask;
            return result.TapAll(next);
        }

        public async Task<Result<IEnumerable<TValue>>> TapAll(Action<TValue> next)
        {
            var result = await resultTask;
            return result.TapAll(next);
        }

        public async Task<Result<IEnumerable<TValue>>> TapAll<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;
            return result.TapAll(next);
        }
    }
}

