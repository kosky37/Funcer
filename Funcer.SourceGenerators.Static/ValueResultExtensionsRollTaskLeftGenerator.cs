using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionsRollTaskLeftGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext initialContext)
    {
        initialContext.RegisterSourceOutput(
            initialContext.CompilationProvider,
            (context, _) =>
            {
                var source = GenerateSource();
                context.AddSource("ValueResultExtensions.Roll.Task.Left.Generated.cs", source);
            });
    }
    
    private static string GenerateSource()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("""
                namespace Funcer;
                
                public static partial class ValueResultExtensions
                {
                    public static async Task<Result<(TValue1, TValue2)>> Roll<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Result<TValue2> next)
                    {
                        var result = await resultTask;
                        return result.Roll(next);
                    }
                
                """);

        for (var count = 2; count <= 16; count++)
        {
            if (count != 2)
            {
                stringBuilder.Append("\n");
            }

            var method = GenerateRollMethod(count);
            stringBuilder.Append(method);
        }

        stringBuilder.Append("}");

        return stringBuilder.ToString();
    }

    private static string GenerateRollMethod(int inputTupleSize)
    {
        var outputTupleSize = inputTupleSize + 1;
        var inputTupleTypes = string.Join(", ", Enumerable.Range(1, inputTupleSize).Select(i => $"TValue{i}"));
        var outputTupleTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));

        return $$"""
                    public static async Task<Result<({{outputTupleTypes}})>> Roll<{{outputTupleTypes}}>(this Task<Result<({{inputTupleTypes}})>> resultTask, Result<TValue{{outputTupleSize}}> next)
                    {
                        var result = await resultTask;
                        return result.Roll(next);
                    }

                """;
    }
}