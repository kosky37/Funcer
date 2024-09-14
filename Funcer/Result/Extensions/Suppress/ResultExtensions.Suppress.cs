namespace Funcer;

public static partial class ResultExtensions
{
#if NET9_0_OR_GREATER
    public static Result Suppress(this Result result, params IEnumerable<string> errorTypes)
#else
    public static Result Suppress(this Result result, params string[] errorTypes)
#endif
    {
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}