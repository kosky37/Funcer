using Funcer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Funcer;

public static partial class ValueResultExtensions
{

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IEnumerable<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IEnumerable<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IEnumerable<TValue>> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IEnumerable<TValue>> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }
}
