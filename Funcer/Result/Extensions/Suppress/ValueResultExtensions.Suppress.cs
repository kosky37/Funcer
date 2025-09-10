namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result Suppress<TValue>(this Result<TValue> result, params IEnumerable<string> errorTypes)
    {
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Count is not 0 ? Result.Failure(remainingErrors) : Result.Success();
    }
}