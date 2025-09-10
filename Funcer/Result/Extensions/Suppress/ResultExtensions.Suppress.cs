namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Suppress(this Result result, params IEnumerable<string> errorTypes)
    {
        if(result.IsSuccess) return result;

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Count is not 0 ? Result.Failure(remainingErrors) : Result.Success();
    }
}