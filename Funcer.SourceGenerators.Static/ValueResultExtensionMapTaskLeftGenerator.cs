using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionMapTaskLeftGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext initialContext)
    {
        initialContext.RegisterSourceOutput(
            initialContext.CompilationProvider,
            (context, _) =>
            {
                var source = GenerateSource();
                context.AddSource("ValueResultExtensions.Map.Task.Left.Generated.cs", source);
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

        return $$"""
                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, Result<TValue>> next)
                    {
                        var result = await resultTask;
                        return result.Map(next);
                    }

                    public static async Task<Result<TValue>> Map<{{inputTypes}}, TValue>(this Task<Result<({{inputTypes}})>> resultTask, Func<{{inputTypes}}, TValue> next)
                    {
                        var result = await resultTask;
                        return result.Map(next);
                    }

                """;
    }
}

