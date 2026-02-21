namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        // bool condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for bool condition

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for Func<bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Func<TValue, bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        // Mixed overloads for Func<TValue, bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            var result = await resultTask;
            return result.Fork(condition, onTrue, onFalse);
        }
    }
}
