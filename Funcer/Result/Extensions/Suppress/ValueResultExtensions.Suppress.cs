namespace Funcer;

public static partial class ValueResultExtensions
{
#if NET9_0_OR_GREATER
    public static Result Suppress<TValue>(this Result<TValue> result, params IEnumerable<string> errorTypes)
#else
    public static Result Suppress<TValue>(this Result<TValue> result, params string[] errorTypes)
#endif
    {
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}