using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators
{
    [Generator]
    public class ResultCombineGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("""
                namespace Funcer;
                
                public partial class Result
                {
                
                """);

            for (var count = 2; count <= 16; count++)
            {
                if (count != 2)
                {
                    stringBuilder.Append("\n");
                }
                var method = GenerateCombineMethod(count);
                stringBuilder.Append(method);
            }

            stringBuilder.Append("""}""");
            context.AddSource("Result.Combine.Generated.cs", SourceText.From(stringBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context) { }

        private static string GenerateCombineMethod(int parameterCount)
        {
            var parameterTypes = string.Join(", ", Enumerable.Range(1, parameterCount).Select(i => $"TValue{i}"));
            var valueResultParameters = string.Join(", ", Enumerable.Range(1, parameterCount).Select(i => $"Result<TValue{i}> result{i}"));
            var valueResults = string.Join(", ", Enumerable.Range(1, parameterCount).Select(i => $"result{i}"));
            var valueTuple = string.Join(", ", Enumerable.Range(1, parameterCount).Select(i => $"result{i}.Value!"));
            
            return $$"""
                    public static Result<({{parameterTypes}})> Combine<{{parameterTypes}}>({{valueResultParameters}}, params Result[] results)
                    {
                        var errors = new List<IResult> { {{valueResults}} }
                            .Concat(results)
                            .Where(result => result.IsFailure)
                            .SelectMany(result => result.Errors)
                            .ToList();
                
                        return errors.Any()
                            ? Result<({{parameterTypes}})>.Failure(errors)
                            : Result<({{parameterTypes}})>.Success(({{valueTuple}}));
                    }

                """;
        }
    }
}