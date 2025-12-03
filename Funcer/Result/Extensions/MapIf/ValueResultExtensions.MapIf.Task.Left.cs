namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> MapIf(bool condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.MapIf(condition, next);
        }

        public async Task<Result<TValue>> MapIf(bool condition, Func<TValue, TValue> mapping)
        {
            var result = await resultTask;

            return result.MapIf(condition, mapping);
        }

        public async Task<Result<TValue>> MapIf(Func<bool> condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.MapIf(condition, next);
        }

        public async Task<Result<TValue>> MapIf(Func<bool> condition, Func<TValue, TValue> mapping)
        {
            var result = await resultTask;

            return result.MapIf(condition, mapping);
        }

        public async Task<Result<TValue>> MapIf(Func<TValue, bool> condition, Func<Result<TValue>> next)
        {
            var result = await resultTask;

            return result.MapIf(condition, next);
        }

        public async Task<Result<TValue>> MapIf(Func<TValue, bool> condition, Func<TValue, TValue> mapping)
        {
            var result = await resultTask;

            return result.MapIf(condition, mapping);
        }
    }
}