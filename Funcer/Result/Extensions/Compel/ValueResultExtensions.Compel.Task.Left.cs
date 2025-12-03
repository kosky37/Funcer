using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<TValue> Compel(Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
        {
            var result = await resultTask;
            if (result.IsFailure) throw exception(result.Errors);

            return result.Value!;
        }
    }
}