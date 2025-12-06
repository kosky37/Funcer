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

        public async Task<Result<TValue>> Ensure(Result<bool> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<Result<bool>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Result<bool>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(bool condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Result<bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<Result<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Result<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return result.Ensure(condition, errorFactory);
        }
    }
}