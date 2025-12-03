using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> WarnIf(bool condition, WarningMessage warning)
        {
            var result = await resultTask;
            return result.WarnIf(condition, warning);
        }

        public async Task<Result<TValue>> WarnIf(Func<bool> condition, WarningMessage warning)
        {
            var result = await resultTask;
            return result.WarnIf(condition, warning);
        }

        public async Task<Result<TValue>> WarnIf(Func<TValue, bool> condition, WarningMessage warning)
        {
            var result = await resultTask;
            return result.WarnIf(condition, warning);
        }
    }
}