using System.Linq;
using System.Text;
using Funcer.SourceGenerators.Static.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionMapTaskGenerator : StaticSourceGenerator
{
    protected override void Generate(GeneratorPostInitializationContext context)
    {
        var sourceBuilder = new StringBuilder();

        sourceBuilder.Append("""
                namespace Funcer;
                
                [ValueTaskVariantGenerator]
                public static class ValueResultExtensions_Map_Tuple_Task
                {
                
                """);

        for (var count = 2; count <= 16; count++)
        {
            if (count != 2)
            {
                sourceBuilder.Append("\n");
            }
            var method = GenerateMapMethod(count);
            sourceBuilder.Append(method);
        }

        sourceBuilder.Append("""}""");
        
        context.AddSource("ValueResultExtensions.Map.Tuple.Task.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }
    
    private static string GenerateMapMethod(int outputTupleSize)
    {
        var inputTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var outputValues = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result.Value!.Item{i}"));

        return $$"""
                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, Task<Result<TValue>>> next)
                    {
                        var result = await resultTask;

                        return await result.Map(next);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, Result<TValue>> next)
                    {
                        var result = await resultTask;

                        return result.Map(next);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, Task<Result<TValue>>> next)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : await next({{outputValues}});
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, Task<TValue>> next)
                    {
                        var result = await resultTask;

                        return await result.Map(next);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, TValue> next)
                    {
                        var result = await resultTask;

                        return result.Map(next);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, Task<TValue>> next)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next({{outputValues}})).WithContext(result);
                    }

                """;
    }
}