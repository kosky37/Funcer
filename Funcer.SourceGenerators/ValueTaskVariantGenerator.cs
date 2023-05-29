using Funcer.SourceGenerators.Common;
using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators;

[Generator]
public class ValueTaskVariantGenerator : ClassScopedGenerator
{
    protected override string AttributeName => nameof(ValueTaskVariantGenerator);
    protected override void Generate(GeneratorExecutionContext context, AttributeSyntaxReceiver syntaxReceiver)
    {
        foreach (var classDeclaration in syntaxReceiver.Classes)
        {
            if (classDeclaration is null) continue;

            var taskVariant = classDeclaration.Parent?.Parent?.ToString();
            
            if (taskVariant is null) continue;
            
            var taskVariantFileName = Tools.GetFileName(classDeclaration);
            var valueTaskVariantFileName = taskVariantFileName.Replace("Task", "ValueTask");
            var valueTaskVariant = taskVariant
                .Replace($"[{AttributeName}]\r\n", "")
                .Replace($"[{AttributeName}]\n", "")
                .Replace("CompletedTask", "Temp1")
                .Replace("Task", "ValueTask")
                .Replace("Temp1", "CompletedTask");
            
            context.AddSource(valueTaskVariantFileName, valueTaskVariant);
        }
    }
}