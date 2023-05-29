using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Funcer.SourceGenerators.Common;

public static class Tools
{
    public static string GetFileName(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var syntaxTree = classDeclarationSyntax.SyntaxTree;
        var filePath = syntaxTree.FilePath;

        return string.IsNullOrEmpty(filePath) ? "Unknown" : Path.GetFileName(filePath);
    }
}