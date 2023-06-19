namespace Funcer;

public static class ValueResultExtensions_Suppress_ValueTask
{
    public static async ValueTask<Result> Suppress<TValue>(this ValueTask<Result<TValue>> resultValueTask, params string[] errorTypes)
    {
        var result = await resultValueTask;
        
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}