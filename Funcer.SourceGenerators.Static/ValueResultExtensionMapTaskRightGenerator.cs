using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionMapTaskRightGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext initialContext)
    {
        initialContext.RegisterSourceOutput(
            initialContext.CompilationProvider,
            (context, _) =>
            {
                var source = GenerateSource();
                context.AddSource("ValueResultExtensions.Map.Task.Right.Generated.cs", source);
            });
    }

    private static string GenerateSource()
    {
        var sourceBuilder = new StringBuilder();

        sourceBuilder.Append("""
                namespace Funcer;
                
                public static partial class ValueResultExtensions
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

        sourceBuilder.Append("}");

        return sourceBuilder.ToString();
    }
    
    private static string GenerateMapMethod(int outputTupleSize)
    {
        var inputTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var outputValues = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result.Value!.Item{i}"));

        return $$"""
                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, Task<Result<TValue>>> nextTask)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await nextTask({{outputValues}})).WithContext(result);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Result<({{inputTypes}})> result, Func<{{inputTypes}}, Task<TValue>> nextTask)
                    {
                        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await nextTask({{outputValues}})).WithContext(result);
                    }

                """;
    }
}

