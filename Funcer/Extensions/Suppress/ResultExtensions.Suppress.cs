namespace Funcer;

public static class ResultExtensions_Suppress
{
    public static Result Suppress(this Result result, params string[] errorTypes)
    {
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success().WithContext(result);
    }
}