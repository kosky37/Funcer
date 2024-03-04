# Funcer
![Main](https://github.com/piotr121993/Funcer/actions/workflows/dotnet.yml/badge.svg)
[![NuGet downloads](https://img.shields.io/nuget/v/funcer.svg)](https://www.nuget.org/packages/Funcer/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/piotr121993/Funcer/blob/main/LICENSE)

This library helps you write a C# code in a functional way. It is inspired by the CSharpFunctionalExtensions library, but focuses solely on the Result type.

## What makes it different?
It uses an `ErrorMessage` type for errors, that is not just an error message but also a type, which allows to map, suppress or otherwise handle specific errors, while making sure that creating new error types is not too verbose. The `ErrorMessage` also has an optional field `Field` for usage with field validation, so that you can correlate an error message to a specific field.

It is an opinionated solution, but I believe it is better then the alternatives:
- simple string: very easy to instantiate but not very versatile
- generic type: can be custom tailored but the types that need to be used get very verbose, the addition af a result itself is already making types comlicated. let's say we want to have `MyType` returned, the type need for a simple return like that might look something like this `Task<Result<MyType, ValidationErrorType>>>`
- strictly typed errors, with each error being a separate class: adds the most flexibility, but it needs a lot of code

The failure `Result` is not limited to a single error message. The result stores a list of error messages, so that it's possible to, for example, validate object's fields and return all the issues.

It also adds a `WarningMessage` type passed with the successful `Result`. It is an idea I'm toying with right now, so it might still need a little polish. It allows to create an optional part of the functions chain, while still getting a feedback from that part. It has the same structure as the `ErrorMessage` and in fact the list of errors can be downgraded to warnings.

## API examples:

### General notes
In principle:
- conditions should accept:
  - boolean `true/false`
  - function returning boolean `() => true`. Sometimes with a parameter `arg => arg > 0`
  - a task returning boolean `() => Task.FromResult(true)` or `arg => Task.FromResult(arg > 0)`
- chain methods should accept both sync and async functions `.Map(arg => arg + 1)` `.Map(arg => Task.FromResult(arg = 1)`

### Static methods

#### Create
Returns Success or Failure result depending on the value of the condition parameter
```csharp
var condition = true;
//just the Result
Result result = Result.Create(condition, new ErrorMessage("errorType", "Error message"));
//or a ValueResult
Result<string> valueResult = Result.Create(condition, "some value", new ErrorMessage("errorType", "Error message"));
```

#### Success
```csharp
Result result = Result.Success();
Result<string> valueResult = Result.Success("some value);
```

#### Failure
```csharp
Result result = Result.Failure(new ErrorMessage("errorType", "Error message"));
Result<SomeType> valueResult = Result.Failure<SomeType>(new ErrorMessage("errorType", "Error message"));
```

#### Ensure

```csharp
SomeType? variable;

Result<SomeType> valueResult = Result.Ensure.HasValue(variable);
```

#### Combine
```csharp
Result result1;
Result result2;
Result<int> valueResult1;
Result<int> valueResult2;

//if there are multiple types of results combined, only the Result will be returned
Result result = Result.Combine(result1, result2, result3);
//when possible (all the combined Results have the same type) a list of received values will be returned
Result<IEnumberable<int>> valueResult = Result.Combine(result1, result2, result3);
```

### Extension methods

#### Map
On Success, performs mutating action
#### MapIf
On Success, if the condition is met, performs non mutating action
#### Tap
On Success, performs non mutating action
#### TapIf
On Success, if the condition is met, performs non mutating action
#### Resolve
On either Success or Failure resolves Result into a single value
#### Side
On Success, performs a non essential action (Result of that action will not change the Result of the mine pipeline, instead, it's result will be converted into a warning)
#### Log
On Failure, it will perform an action
#### Ensure
Checks a condition and changes the Result accordingly
#### Compel
On Failure, throws an exception
#### Suppress
Removes errors of a specified type
#### HandleError
Removes errors of a specified type. Allows a callback. The callback can be used to infer a return value.
#### HandleWarning
Removes warnings of a specified type. Allows a callback.
#### Warn
Adds warning.
#### WarnIf
Adds warning if the condition is met