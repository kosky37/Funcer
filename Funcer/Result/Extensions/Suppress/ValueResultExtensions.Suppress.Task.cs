namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result> Suppress(params IEnumerable<string> errorTypes)
        {
            var result = await resultTask;
        
            if(result.IsSuccess) return Result.Success().WithContext(result);

            var remainingErrors = result.Errors.Where(e => !errorTypes.Contains(e.Type)).ToList();

            return remainingErrors.Count is not 0 ? Result.Failure(remainingErrors) : Result.Success();
        }
    }
}