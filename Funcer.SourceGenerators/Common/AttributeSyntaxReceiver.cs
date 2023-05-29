using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Funcer.SourceGenerators.Common;

public class AttributeSyntaxReceiver : ISyntaxReceiver
{
    private readonly string _attributeName;

    public AttributeSyntaxReceiver(string attributeName)
    {
        _attributeName = attributeName;
    }
    
    public IList<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is ClassDeclarationSyntax { AttributeLists.Count: > 0 } classDeclarationSyntax)
        {
            foreach (var attributeList in classDeclarationSyntax.AttributeLists)
            {
                foreach (var attribute in attributeList.Attributes)
                {
                    if (attribute.Name.ToString() == _attributeName)
                    {
                        Classes.Add(classDeclarationSyntax);
                    }
                }
            }
        }
    }
}