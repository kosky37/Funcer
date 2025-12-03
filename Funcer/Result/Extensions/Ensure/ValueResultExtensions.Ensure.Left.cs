using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Ensure(bool condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<bool> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, bool> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }
    }
}