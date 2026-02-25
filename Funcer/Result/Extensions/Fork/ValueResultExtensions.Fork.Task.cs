namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        // bool condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Mixed overloads for bool condition

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(bool condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        // Func<TValue, bool> condition overloads

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<TValue, bool> condition

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> onTrue, Func<Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue(result.Value!)).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> onTrue, Func<TValue, Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<Task<Result<TValue2>>> onTrue, Func<TValue, Task<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse(result.Value!)).WithContext(result);
        }

        public async Task<Result<TValue2>> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<TValue2>> onTrue, Func<Task<Result<TValue2>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(await onTrue(result.Value!)).WithContext(result)
                : (await onFalse()).WithContext(result);
        }
    }
}
