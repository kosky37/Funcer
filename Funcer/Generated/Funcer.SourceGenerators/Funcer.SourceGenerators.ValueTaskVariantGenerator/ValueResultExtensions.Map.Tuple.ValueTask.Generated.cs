namespace Funcer;

public static class ValueResultExtensions_Map_Tuple_ValueTask
{
    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this ValueTask<Result<(TValue1, TValue2)>> resultValueTask, Func<TValue1, TValue2, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this ValueTask<Result<(TValue1, TValue2)>> resultValueTask, Func<TValue1, TValue2, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this Result<(TValue1, TValue2)> result, Func<TValue1, TValue2, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this ValueTask<Result<(TValue1, TValue2)>> resultValueTask, Func<TValue1, TValue2, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this ValueTask<Result<(TValue1, TValue2)>> resultValueTask, Func<TValue1, TValue2, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue>(this Result<(TValue1, TValue2)> result, Func<TValue1, TValue2, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3)>> resultValueTask, Func<TValue1, TValue2, TValue3, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3)>> resultValueTask, Func<TValue1, TValue2, TValue3, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Result<(TValue1, TValue2, TValue3)> result, Func<TValue1, TValue2, TValue3, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3)>> resultValueTask, Func<TValue1, TValue2, TValue3, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Result<(TValue1, TValue2, TValue3)> result, Func<TValue1, TValue2, TValue3, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Func<TValue1, TValue2, TValue3, TValue4, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Func<TValue1, TValue2, TValue3, TValue4, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15)).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, result.Value!.Item16);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this ValueTask<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultValueTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue> next)
    {
        var result = await resultValueTask;

        return result.Map(next);
    }

    public static async ValueTask<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next(result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, result.Value!.Item16)).WithContext(result);
    }
}