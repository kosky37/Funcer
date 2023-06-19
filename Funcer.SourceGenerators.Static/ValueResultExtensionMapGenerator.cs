using System.Linq;
using System.Text;
using Funcer.SourceGenerators.Static.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionMapGenerator : StaticSourceGenerator
{
    protected override void Generate(GeneratorPostInitializationContext context)
    {
        var sourceBuilder = new StringBuilder();

        sourceBuilder.Append("""
                namespace Funcer;
                
                public static class ValueResultExtensions_Map_Tuple
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
        
        context.AddSource("ValueResultExtensions.Map.Tuple.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }
    
    private static string GenerateMapMethod(int outputTupleSize)
    {
        var inputTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var outputValues = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result.Value!.Item{i}"));

        return $$"""
                    public static Result<TValue> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, Result<TValue>> next)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : next({{outputValues}});
                    }

                    public static Result<TValue> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, TValue> next)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(next({{outputValues}})).WithContext(result);
                    }

                """;
    }
}