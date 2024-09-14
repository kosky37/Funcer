namespace Funcer;

public static partial class ValueResultExtensions
{
#if NET9_0_OR_GREATER
    public static async Task<Result> Suppress<TValue>(this Task<Result<TValue>> resultTask, params IEnumerable<string> errorTypes)
#else
    public static async Task<Result> Suppress<TValue>(this Task<Result<TValue>> resultTask, params string[] errorTypes)
#endif
    {
        var result = await resultTask;
        
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}