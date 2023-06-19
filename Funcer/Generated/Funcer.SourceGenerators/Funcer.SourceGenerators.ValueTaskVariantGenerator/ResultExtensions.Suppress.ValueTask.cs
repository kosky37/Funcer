namespace Funcer;

public static class ResultExtensions_Suppress_ValueTask
{
    public static async ValueTask<Result> Suppress(this ValueTask<Result> resultValueTask, params string[] errorTypes)
    {
        var result = await resultValueTask;
        
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}