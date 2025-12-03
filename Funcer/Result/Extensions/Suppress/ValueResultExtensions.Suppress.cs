namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result Suppress(params IEnumerable<string> errorTypes)
        {
            if(result.IsSuccess) return Result.Success().WithContext(result);

            var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

            return remainingErrors.Count is not 0 ? Result.Failure(remainingErrors) : Result.Success();
        }
    }
}