using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Warn(WarningMessage warning)
        {
            var result = await resultTask;
            return result.Warn(warning);
        }
    }
}