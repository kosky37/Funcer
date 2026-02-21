namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        // bool condition - Mixed async/sync overloads (onTrue async, onFalse sync)

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        // bool condition - Mixed async/sync overloads (onTrue sync, onFalse async)

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue(result.Value!).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Func<bool> condition - Mixed async/sync overloads (onTrue async, onFalse sync)

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // More Func<bool> mixed combinations...
        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        // Func<bool> condition - Mixed async/sync overloads (onTrue sync, onFalse async)

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue(result.Value!).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // More combinations...
        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Func<TValue, bool> condition - Mixed async/sync overloads (onTrue async, onFalse sync)

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // More combinations for Func<TValue, bool>...
        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        // Func<TValue, bool> condition - Mixed async/sync overloads (onTrue sync, onFalse async)

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue(result.Value!).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // More combinations...
        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }
    }
}
