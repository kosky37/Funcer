namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<(TValue1, TValue2)>> Roll<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<Task<Result<TValue2>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }
    public static async Task<Result<(TValue1, TValue2, TValue3)>> Roll<TValue1, TValue2, TValue3>(this Task<Result<(TValue1, TValue2)>> resultTask, Func<Task<Result<TValue3>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4)>> Roll<TValue1, TValue2, TValue3, TValue4>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Func<Task<Result<TValue4>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Func<Task<Result<TValue5>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Func<Task<Result<TValue6>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Func<Task<Result<TValue7>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Func<Task<Result<TValue8>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Func<Task<Result<TValue9>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Func<Task<Result<TValue10>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Func<Task<Result<TValue11>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Func<Task<Result<TValue12>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Func<Task<Result<TValue13>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Func<Task<Result<TValue14>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Func<Task<Result<TValue15>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Func<Task<Result<TValue16>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Func<Task<Result<TValue17>>> nextTask)
    {
        var result = await resultTask;
        return await result.Roll(nextTask);
    }
}