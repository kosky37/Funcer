namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Side(Func<Result> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }

        public async Task<Result<TValue>> Side(Func<TValue, Result> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<Result<TValue2>> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;

            return result.Side(next);
        }
    }
}