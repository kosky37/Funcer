namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Task<Result<(TValue1, TValue2)>> resultTask, Func<TValue1, TValue2, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue>(this Task<Result<(TValue1, TValue2)>> resultTask, Func<TValue1, TValue2, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Func<TValue1, TValue2, TValue3, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Func<TValue1, TValue2, TValue3, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Task<Result<TValue>>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }

    public static async Task<Result<TValue>> Map<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Func<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, Task<TValue>> nextTask)
    {
        var result = await resultTask;
        return await result.Map(nextTask);
    }
}