namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        // bool condition - onTrue async, onFalse sync

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Func<bool> condition - onTrue async, onFalse sync

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Func<TValue, bool> condition - onTrue async, onFalse sync

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }
    }
}
