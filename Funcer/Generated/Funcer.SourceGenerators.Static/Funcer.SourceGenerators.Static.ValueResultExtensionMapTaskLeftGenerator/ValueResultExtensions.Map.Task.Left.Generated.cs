namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Task<Result<(TValue1, TValue2)>> resultTask, Func<TValue1, TValue2, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Task<Result<(TValue1, TValue2)>> resultTask, Func<TValue1, TValue2, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Func<TValue1, TValue2, TValue3, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Func<TValue1, TValue2, TValue3, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
}