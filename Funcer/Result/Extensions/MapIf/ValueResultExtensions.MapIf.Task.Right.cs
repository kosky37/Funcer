namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> MapIf(bool condition, Func<Task<Result<TValue>>> next)
        {
            return result.IsFailure || !condition ? result : (await next()).WithContext(result);
        }

        public async Task<Result<TValue>> MapIf(bool condition, Func<TValue, Task<TValue>> mapping)
        {
            return result.IsFailure || !condition ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue>> MapIf(Func<bool> condition, Func<Task<Result<TValue>>> next)
        {
            return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
        }

        public async Task<Result<TValue>> MapIf(Func<bool> condition, Func<TValue, Task<TValue>> mapping)
        {
            return result.IsFailure || !condition() ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue>> MapIf(Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
        {
            return result.IsFailure || !condition(result.Value!) ? result : (await next()).WithContext(result);
        }

        public async Task<Result<TValue>> MapIf(Func<TValue, bool> condition, Func<TValue, Task<TValue>> mapping)
        {
            return result.IsFailure || !condition(result.Value!) ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
        }
    }
}