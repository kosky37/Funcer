using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<TValue> Compel(Func<IReadOnlyCollection<ErrorMessage>, Task<Exception>> exception)
        {
            if (result.IsFailure) throw await exception(result.Errors);

            return result.Value!;
        }
    }
}