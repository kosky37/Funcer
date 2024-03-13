namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Suppress(this Result result, params string[] errorTypes)
    {
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}