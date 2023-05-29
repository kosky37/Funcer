using Microsoft.CodeAnalysis;

namespace Funcer.SourceGenerators.Static.Common;

public abstract class StaticSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context) => context.RegisterForPostInitialization(Generate);

    public void Execute(GeneratorExecutionContext context) { }

    protected abstract void Generate(GeneratorPostInitializationContext context);
}