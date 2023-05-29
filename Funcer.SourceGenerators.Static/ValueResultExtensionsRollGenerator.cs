using System.Linq;
using System.Text;
using Funcer.SourceGenerators.Static.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ValueResultExtensionsRollGenerator : StaticSourceGenerator
{
    protected override void Generate(GeneratorPostInitializationContext context)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("""
                namespace Funcer;
                
                public static partial class ValueResultExtensions
                {
                    public static Result<(TValue1, TValue2)> Roll<TValue1, TValue2>(this Result<TValue1> result, Result<TValue2> next)
                    {
                        return result.IsFailure 
                        ? Result.Failure<(TValue1, TValue2)>(result.Errors) 
                        : next.IsFailure 
                            ? Result.Failure<(TValue1, TValue2)>(next.Errors) 
                            : Result.Success((result.Value!, next.Value!));
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

        stringBuilder.Append("""}""");
        context.AddSource("ValueResultExtensions.Roll.Generated.cs",
            SourceText.From(stringBuilder.ToString(), Encoding.UTF8));
    }

    private static string GenerateRollMethod(int inputTupleSize)
    {
        var outputTupleSize = inputTupleSize + 1;
        var inputTupleTypes = string.Join(", ", Enumerable.Range(1, inputTupleSize).Select(i => $"TValue{i}"));
        var outputTupleTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var outputTupleValues = string.Join(", ",
            Enumerable.Range(1, inputTupleSize).Select(i => $"result.Value!.Item{i}"));

        return $$"""
                    public static Result<({{outputTupleTypes}})> Roll<{{outputTupleTypes}}>(this Result<({{inputTupleTypes}})> result, Result<TValue{{outputTupleSize}}> next)
                    {
                        return result.IsFailure 
                            ? Result.Failure<({{outputTupleTypes}})>(result.Errors) 
                            : next.IsFailure 
                                ? Result.Failure<({{outputTupleTypes}})>(next.Errors) 
                                : Result.Success(({{outputTupleValues}}, next.Value!));
                    }

                """;
    }
}