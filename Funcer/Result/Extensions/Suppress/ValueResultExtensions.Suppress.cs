namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result Suppress<TValue>(this Result<TValue> result, params string[] errorTypes)
    {
        if(result.IsSuccess) return Result.Success().WithContext(result);

        var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

        return remainingErrors.Any() ? Result.Failure(remainingErrors) : Result.Success();
    }
}