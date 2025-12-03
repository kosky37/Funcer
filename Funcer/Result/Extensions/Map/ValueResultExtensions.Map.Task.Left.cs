namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Map(Func<Result<TValue>> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue2> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }

        public async Task<Result<TValue2>> Map<TValue2>(Func<TValue, TValue2> next)
        {
            var result = await resultTask;
            return result.Map(next);
        }
    }
}