using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Funcer.SourceGenerators.Common;

public abstract class ClassScopedGenerator : ISourceGenerator
{
    protected abstract string AttributeName { get; }
    
    protected abstract void Generate(GeneratorExecutionContext context, AttributeSyntaxReceiver syntaxReceiver);
    
    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not AttributeSyntaxReceiver syntaxReceiver) return;
        Generate(context, syntaxReceiver);
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization(callback =>
        {
            callback.AddSource("Attributes_GenerateTaskVariant", SourceText.From($$"""
                namespace Funcer.Generator.Attributes;
                
                [AttributeUsage(AttributeTargets.Class)]
                public class {{AttributeName}}Attribute : Attribute { }
                """, Encoding.UTF8));
        });
        
        context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver(AttributeName));
    }
}