namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Suppress(params IEnumerable<string> errorTypes)
        {
            if(result.IsSuccess) return result;

            var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

            return remainingErrors.Count is not 0 ? Result.Failure(remainingErrors) : Result.Success();
        }
    }
}