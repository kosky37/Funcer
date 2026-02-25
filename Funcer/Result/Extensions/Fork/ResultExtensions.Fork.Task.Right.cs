namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        // bool condition overloads

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<Result<TValue>>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<Result<TValue>>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }
    }
}
