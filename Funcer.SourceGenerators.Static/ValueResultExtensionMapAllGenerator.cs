using System.Text;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionMapAllGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx =>
        {
            var source = GenerateSource();
            ctx.AddSource("ValueResultExtensions.MapAll.Overloads.Generated.cs", source);
        });
    }

    private static string GenerateSource()
    {
        var sb = new StringBuilder();
        sb.AppendLine("using Funcer.Helpers;");
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Generic;");
        sb.AppendLine("using System.Linq;");
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine("using System.Threading.Tasks;");
        sb.AppendLine();
        sb.AppendLine("namespace Funcer;");
        sb.AppendLine();
        sb.AppendLine("public static partial class ValueResultExtensions");
        sb.AppendLine("{");

        var types = new[]
        {
            ("IEnumerable", "IEnumerable<TValue>"),
            ("List", "List<TValue>"),
            ("IList", "IList<TValue>"),
            ("IReadOnlyCollection", "IReadOnlyCollection<TValue>"),
            ("ICollection", "ICollection<TValue>"),
            ("Array", "TValue[]")
        };

        foreach (var (_, type) in types)
        {
            GenerateSync(sb, type);
            GenerateTask(sb, type);
            GenerateTaskLeft(sb, type);
            GenerateTaskRight(sb, type);
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    private static void GenerateSync(StringBuilder sb, string type)
    {
        sb.Append($$"""

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<{{type}}> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<{{type}}> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value.Select(next)).WithContext(result);
    }

""");
    }

    private static void GenerateTask(StringBuilder sb, string type)
    {
        sb.Append($$"""

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<{{type}}>> resultTask, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
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

        return Result.Success(mappedResults.Select(x => x.Value)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<{{type}}>> resultTask, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

""");
    }

    private static void GenerateTaskLeft(StringBuilder sb, string type)
    {
        sb.Append($$"""

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<{{type}}>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<{{type}}>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

""");
    }

    private static void GenerateTaskRight(StringBuilder sb, string type)
    {
        sb.Append($$"""

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<{{type}}> result, Func<TValue, Task<Result<TValue2>>> next, bool parallel = true)
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

        return Result.Success(mappedResults.Select(x => x.Value)).WithContext(result);
    }

    [OverloadResolutionPriority(1)]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<{{type}}> result, Func<TValue, Task<TValue2>> next, bool parallel = true)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = parallel ? await Task.WhenAll(result.Value.Select(next)) : (await result.Value.Select(next).ExecuteSequentially()).ToArray();
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

""");
    }
}
