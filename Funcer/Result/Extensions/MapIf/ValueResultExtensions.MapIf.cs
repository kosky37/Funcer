namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> MapIf(bool condition, Func<Result<TValue>> next)
        {
            return result.IsFailure || !condition ? result : next().WithContext(result);
        }

        public Result<TValue> MapIf(bool condition, Func<TValue, TValue> mapping)
        {
            return result.IsFailure || !condition ? result : Result.Success(mapping(result.Value!)).WithContext(result);
        }

        public Result<TValue> MapIf(Func<bool> condition,
            Func<Result<TValue>> next)
        {
            return result.IsFailure || !condition() ? result : next().WithContext(result);
        }

        public Result<TValue> MapIf(Func<bool> condition,
            Func<TValue, TValue> mapping)
        {
            return result.IsFailure || !condition() ? result : Result.Success(mapping(result.Value!)).WithContext(result);
        }

        public Result<TValue> MapIf(Func<TValue, bool> condition,
            Func<Result<TValue>> next)
        {
            return result.IsFailure || !condition(result.Value!) ? result : next().WithContext(result);
        }

        public Result<TValue> MapIf(Func<TValue, bool> condition,
            Func<TValue, TValue> mapping)
        {
            return result.IsFailure || !condition(result.Value!) ? result : Result.Success(mapping(result.Value!)).WithContext(result);
        }
    }
}