namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        // bool condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for bool condition

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for Func<bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Func<TValue, bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for Func<TValue, bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            var result = await resultTask;
            return await result.Fork(condition, onTrue, onFalse);
        }
    }
}
