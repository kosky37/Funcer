using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static;

[Generator]
public class ResultCombineGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext initialContext)
    {
        initialContext.RegisterSourceOutput(
            initialContext.CompilationProvider,
            (context, _) =>
            {
                var source = GenerateSource();
                context.AddSource("Result.Combine.Generated.cs", source);
            });
    }
    
    private static string GenerateSource()
    {
        var sourceBuilder = new StringBuilder();

        sourceBuilder.Append("""
                             namespace Funcer;

                             public partial struct Result
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

        sourceBuilder.Append("}");

        return sourceBuilder.ToString();
    }
    
    private static string GenerateCombineMethod(int outputTupleSize)
    {
        var outputTupleTypes = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"TValue{i}"));
        var inputValueResults = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"Result<TValue{i}> result{i}"));
        var valueResults = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result{i}"));
        var outputTupleValue = string.Join(", ", Enumerable.Range(1, outputTupleSize).Select(i => $"result{i}.Value!"));
            
        return $$"""
                    public static Result<({{outputTupleTypes}})> Combine<{{outputTupleTypes}}>({{inputValueResults}}, params IResult[] results)
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