namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Tap(Func<Result<TValue>> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Func<TValue, Result> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Action next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result<TValue>> Tap(Action<TValue> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<TValue2> next)
        {
            var result = await resultTask;
            return result.Tap(next);
        }
    }
}