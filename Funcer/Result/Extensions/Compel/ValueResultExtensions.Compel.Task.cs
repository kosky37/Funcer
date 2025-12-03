using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<TValue> Compel()
        {
            var result = await resultTask;
            if (result.IsFailure) throw new FailureResultException(result.Errors);

            return result.Value!;
        }

        public async Task<TValue> Compel(Func<IReadOnlyCollection<ErrorMessage>, Task<Exception>> exception)
        {
            var result = await resultTask;
            if (result.IsFailure) throw await exception(result.Errors);

            return result.Value!;
        }
    }
}