using System.Linq;
using System.Text;
using Funcer.SourceGenerators.Static.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ResultCombineGenerator : StaticSourceGenerator
{
    protected override void Generate(GeneratorPostInitializationContext context)
    {
        var sourceBuilder = new StringBuilder();

        sourceBuilder.Append("""
                namespace Funcer;
                
                public partial class Result
                {
                
                """);

        for (var count = 2; count <= 16; count++)
        {
            if (count != 2)
            {
                sourceBuilder.Append("\n");
            }
            var method = GenerateCombineMethod(count);
            sourceBuilder.Append(method);
        }

        sourceBuilder.Append("""}""");
        
        context.AddSource("Result.Combine.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
    }
    
    private static string GenerateCombineMethod(int outputTupleSize)
    {
        var outputTupleTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var inputValueResults = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"Result<TValue{i}> result{i}"));
        var valueResults = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result{i}"));
        var outputTupleValue = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result{i}.Value!"));
            
        return $$"""
                    public static Result<({{outputTupleTypes}})> Combine<{{outputTupleTypes}}>({{inputValueResults}}, params Result[] results)
                    {
                        var errors = new List<IResult> { {{valueResults}} }
                            .Concat(results)
                            .Where(result => result.IsFailure)
                            .SelectMany(result => result.Errors)
                            .ToList();
                
                        return errors.Any()
                            ? Result<({{outputTupleTypes}})>.Failure(errors)
                            : Result<({{outputTupleTypes}})>.Success(({{outputTupleValue}}));
                    }

                """;
    }
}