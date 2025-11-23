namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Result<(TValue1, TValue2)> result, Func<TValue1, TValue2, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Result<(TValue1, TValue2)> result, Func<TValue1, TValue2, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Result<(TValue1, TValue2, TValue3)> result, Func<TValue1, TValue2, TValue3, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Result<(TValue1, TValue2, TValue3)> result, Func<TValue1, TValue2, TValue3, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Func<TValue1, TValue2, TValue3, TValue4, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Func<TValue1, TValue2, TValue3, TValue4, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Task<Result<TValue>>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, result.Value!.Item16)).WithContext(result);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Task<TValue>> nextTask)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, result.Value!.Item16)).WithContext(result);
    }
}