namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Suppress_Task
{
    public static async Task<Result> Suppress(this Task<Result> resultTask, params string[] errorTypes)
    {
        var result = await resultTask;
        
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}