# Funcer
![Main](https://github.com/piotr121993/Funcer/actions/workflows/dotnet.yml/badge.svg)
[![NuGet downloads](https://img.shields.io/nuget/v/funcer.svg)](https://www.nuget.org/packages/Funcer/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/piotr121993/Funcer/blob/main/LICENSE)

This library helps you write a C# code in a funcional way. It is inspired by the CSharpFunctionalExtensions library, but focuses solely on the Result type.

## What makes it different?
It uses an `ErrorMessage` type for errors, that is not just an error message but also a type, which allows to map, suppress or otherwise handle specific errors, while making sure that creating new error types is not too verbose. The `ErrorMessage` also has an optional field `Field` for usage with field validation, so that you can correlate an error message to a specific field.

It is an opinionated solution, but I believe it is better then the alternatives:
- simple string: very easy to instantiate but not very versatile
- generic type: can be custom tailored but the types that need to be used get very verbose, the addition af a result itself is already making types comlicated. let's say we want to have `MyType` returned, the type need for a simple return like that might look something like this `Task<Result<MyType, ValidationErrorType>>>`
- strictly typed errors, with each error being a separate class: adds the most flexibility, but it needs a lot of code

The failure `Result` is not limited to a single error message. The result stores a list of error messages, so that it's possible to, for example, validate object's fields and return all the issues.

It also adds a `WarningMessage` type passed with the successful `Result`. It is an idea I'm toying with right now, so it might still need a little polish. It allows to create an optional part of the functions chain, while still getting a feedback from that part. It has the same structure as the `ErrorMessage` and in fact the list of errors can be downgraded to warnings.
