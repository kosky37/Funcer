namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Suppress_Task
{
    public static async Task<Result> Suppress<TValue>(this Task<Result<TValue>> resultTask, params string[] errorTypes)
    {
        var result = await resultTask;
        
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}