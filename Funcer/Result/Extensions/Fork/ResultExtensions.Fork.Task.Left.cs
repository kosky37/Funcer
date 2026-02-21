namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        // bool condition overloads

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<Result<TValue>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<TValue> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for bool condition

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<TValue> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<Result<TValue>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<Result<TValue>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<TValue> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for Func<bool> condition

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<TValue> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<Result<TValue>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }
    }
}
