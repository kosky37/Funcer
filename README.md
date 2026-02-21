# Funcer
![Main](https://github.com/piotr121993/Funcer/actions/workflows/dotnet.yml/badge.svg)
[![NuGet downloads](https://img.shields.io/nuget/v/funcer.svg)](https://www.nuget.org/packages/Funcer/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/piotr121993/Funcer/blob/main/LICENSE)

This library helps you write C# code in a functional way. It is inspired by the [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) library, but focuses solely on the Result type and provides a different approach to error handling.

## Comparison with CSharpFunctionalExtensions

### Key Differences

**Error Handling Approach:**
- **CSharpFunctionalExtensions**: Uses simple string error messages (`Result<T, string>`) or generic error types (`Result<T, E>`)
- **Funcer**: Uses a structured `ErrorMessage` type with both a message and a type identifier, providing better error categorization without the verbosity of generic error types

**Error Structure:**
- **CSharpFunctionalExtensions**: Single error per Result (or custom error type)
- **Funcer**: Multiple errors per Result, allowing validation of multiple fields and collecting all issues at once

**Type Complexity:**
- **CSharpFunctionalExtensions**: With generic error types, signatures become verbose: `Task<Result<MyType, ValidationErrorType>>`
- **Funcer**: Simpler signatures: `Result<MyType>` or `Task<Result<MyType>>`, with error types handled through the `ErrorMessage` structure

**Additional Features:**
- **Funcer** adds `WarningMessage` support, allowing non-critical feedback without breaking the success chain
- **Funcer** includes an optional `Field` property on `ErrorMessage` for field-specific validation errors

### Why Choose Funcer?

If you need:
- ✅ Multiple error messages per Result (e.g., form validation with multiple fields)
- ✅ Error categorization without generic type complexity
- ✅ Field-specific error tracking
- ✅ Warning messages alongside successful results
- ✅ A focused library that only handles Result types

Then Funcer might be a better fit than CSharpFunctionalExtensions.

If you need:
- ✅ Maybe types (`Maybe<T>`)
- ✅ Value objects and other functional constructs
- ✅ Generic error types with compile-time safety
- ✅ A more comprehensive functional programming toolkit

Then CSharpFunctionalExtensions might be more suitable.

## API examples:

### General notes

The library follows consistent design principles throughout:

**Condition Parameters:**
Most methods that accept conditions (like `Ensure`, `MapIf`, `TapIf`, `WarnIf`) support multiple overloads:
- Direct boolean values: `result.Ensure(value > 0, error)`
- Synchronous functions: `result.Ensure(() => value > 0, error)` or `result.Ensure(value => value > 0, error)`
- Asynchronous functions: `await result.Ensure(async () => await ValidateAsync(), error)` or `await result.Ensure(async value => await ValidateAsync(value), error)`

**Chain Methods:**
Extension methods that transform or process values (like `Map`, `Tap`, `MapAll`, `TapAll`) support both synchronous and asynchronous operations:
- Synchronous: `result.Map(value => value + 1)`
- Asynchronous: `await result.Map(async value => await ProcessAsync(value))`
- Result-returning functions: `result.Map(value => Result.Success(value * 2))`
- Async Result-returning functions: `await result.Map(async value => await ProcessWithResultAsync(value))`

**Task Variants:**
For methods that work with `Task<Result<T>>`, there are typically three variants:
- **Task** (both result and function are async): `Task<Result<T>>` with `Func<T, Task<TResult>>`
- **Task.Left** (result is async, function is sync): `Task<Result<T>>` with `Func<T, TResult>`
- **Task.Right** (result is sync, function is async): `Result<T>` with `Func<T, Task<TResult>>`

This flexibility allows you to mix synchronous and asynchronous operations seamlessly throughout your code.

### Static methods

#### Create
Returns Success or Failure result depending on the value of the condition parameter
```csharp
var condition = true;
//just the Result
Result result = Result.Create(condition, new ErrorMessage("errorType", "Error message"));

//or a ValueResult
Result<string> valueResult = Result.Create(condition, "some value", new ErrorMessage("errorType", "Error message"));

//with a function returning boolean
Result resultFromFunc = Result.Create(() => condition, new ErrorMessage("errorType", "Error message"));
Result<int> valueResultFromFunc = Result.Create(() => condition, 42, new ErrorMessage("errorType", "Error message"));

//with an async function
Result resultFromTask = await Result.Create(async () => await Task.FromResult(condition), new ErrorMessage("errorType", "Error message"));
Result<string> valueResultFromTask = await Result.Create(async () => await Task.FromResult(condition), "async value", new ErrorMessage("errorType", "Error message"));
```

#### Success
Creates a successful Result with an optional value
```csharp
// Simple success without a value
Result result = Result.Success();

// Success with a value
Result<string> valueResult = Result.Success("some value");
Result<int> intResult = Result.Success(42);
Result<MyType> customResult = Result.Success(new MyType());
```

#### Failure
Creates a failed Result with one or more error messages
```csharp
// Simple failure with a single error
Result result = Result.Failure(new ErrorMessage("errorType", "Error message"));
Result<SomeType> valueResult = Result.Failure<SomeType>(new ErrorMessage("errorType", "Error message"));

// Failure with multiple errors
Result resultWithMultipleErrors = Result.Failure(
    new ErrorMessage("validation", "Field 1 is required"),
    new ErrorMessage("validation", "Field 2 must be positive")
);

// Failure with field-specific error
Result validationError = Result.Failure(
    new ErrorMessage("validation", "Value must be greater than 0", "amount")
);
```

#### Ensure
Static helper for common validation scenarios
```csharp
SomeType? variable;

// Check if a nullable value has a value
Result<SomeType> valueResult = Result.Ensure.HasValue(variable);
// If variable is null, returns Failure with an error message
```

#### Combine
Combines multiple Results into a single Result. If all succeed, returns Success. If any fail, returns Failure with all errors collected.
```csharp
Result result1 = Result.Success();
Result result2 = Result.Success();
Result<int> valueResult1 = Result.Success(1);
Result<int> valueResult2 = Result.Success(2);
Result<int> valueResult3 = Result.Success(3);

// If there are multiple types of results combined, only the Result will be returned
Result result = Result.Combine(result1, result2, valueResult1);
// result.IsSuccess will be true if all succeed

// When all combined Results have the same type, a list of received values will be returned
Result<IEnumerable<int>> valueResult = Result.Combine(valueResult1, valueResult2, valueResult3);
// valueResult.Value will be [1, 2, 3] if all succeed

// If any result fails, all errors are collected
Result<int> failedResult = Result.Failure<int>(new ErrorMessage("error", "Failed"));
Result<IEnumerable<int>> combinedWithFailure = Result.Combine(valueResult1, failedResult, valueResult2);
// combinedWithFailure.IsFailure will be true, and errors will contain the error from failedResult
```

#### Retry
Retries an operation up to a maximum number of attempts. The operation is retried only if it fails with a specific error type. If the operation succeeds or fails with a different error type, it returns immediately without retrying.
```csharp
// Sync version for Result
Result result = Result.Retry(
    attemptNumber => 
    {
        // Operation that may fail with "RetryableError" type
        return SomeOperation();
    },
    errorType: "RetryableError",
    maxTries: 3
);
// Will retry up to 3 times if operation fails with "RetryableError"
// Returns immediately on success or if error type differs

// Sync version for ValueResult (type is inferred)
Result<string> valueResult = Result.Retry(
    attemptNumber => 
    {
        // Operation that may fail with "RetryableError" type
        return SomeOperationReturningString();
    },
    errorType: "RetryableError",
    maxTries: 3
);
// Will retry up to 3 times if operation fails with "RetryableError"

// Async version for Result
Result result = await Result.Retry(
    async attemptNumber => 
    {
        await Task.Delay(100);
        return await SomeAsyncOperation();
    },
    errorType: "RetryableError",
    maxTries: 3
);

// Async version for ValueResult (type is inferred)
Result<int> valueResult = await Result.Retry(
    async attemptNumber => 
    {
        await Task.Delay(100);
        return await SomeAsyncOperationReturningInt();
    },
    errorType: "RetryableError",
    maxTries: 3
);

// Example: Retry only on specific error type
Result result = Result.Retry(
    attemptNumber => 
    {
        // This operation might fail with "NetworkError" or "ValidationError"
        return CallExternalService();
    },
    errorType: "NetworkError",  // Only retry on NetworkError
    maxTries: 5
);
// If operation fails with "NetworkError", it will retry up to 5 times
// If operation fails with "ValidationError", it returns immediately without retrying
// If operation succeeds, it returns immediately

// Example: Using attempt number in the operation
Result<int> result = Result.Retry(
    attemptNumber => 
    {
        // Can use attemptNumber for exponential backoff, logging, etc.
        Console.WriteLine($"Attempt {attemptNumber}");
        return FetchDataWithRetry(attemptNumber);
    },
    errorType: "TransientError",
    maxTries: 3
);
```

### Extension methods

#### Map
On Success, transforms the value using a mapping function. Returns a new Result with the mapped value.
```csharp
Result<int> result = Result.Success(1);

// Map with a simple function
Result<int> mappedResult = result.Map(value => value + 1);
// mappedResult.Value will be 2

// Map to a different type
Result<string> mappedToString = result.Map(value => value.ToString());
// mappedToString.Value will be "1"

// Map with an async function
Result<int> mappedAsync = await result.Map(async value => await Task.FromResult(value * 2));
// mappedAsync.Value will be 2

// Map with a Result-returning function
Result<int> mappedWithResult = result.Map(value => 
    value > 0 
        ? Result.Success(value * 2) 
        : Result.Failure<int>(new ErrorMessage("validation", "Value must be positive")));
// If value > 0, returns Success with doubled value, otherwise Failure

// Map on a non-ValueResult
Result result = Result.Success();
Result<string> mappedFromResult = result.Map(() => "mapped value");
// mappedFromResult.Value will be "mapped value"
```
#### MapIf
On Success, if the condition is met, transforms the value using a mapping function. Otherwise, returns the original Result unchanged.
```csharp
Result<int> result = Result.Success(1);

// Map if condition is true
Result<int> mappedResult = result.MapIf(value => value > 0, value => value + 1);
// mappedResult.Value will be 2 (condition was true)

// Condition not met - original value is returned
Result<int> notMapped = result.MapIf(value => value > 10, value => value + 1);
// notMapped.Value will be 1 (condition was false, original value returned)

// Map with async condition and mapper
Result<int> mappedAsync = await result.MapIf(
    async value => await Task.FromResult(value > 0),
    async value => await Task.FromResult(value * 2)
);
// mappedAsync.Value will be 2

// Map to a different type
Result<string> mappedToString = result.MapIf(
    value => value > 0,
    value => $"Positive: {value}"
);
// mappedToString.Value will be "Positive: 1" if condition is met
```
#### Fork
On Success, evaluates a condition and applies one of two mapping functions based on the result. Unlike MapIf, Fork always produces an output in the desired type by providing separate transformations for both true and false conditions.
```csharp
Result<int> result = Result.Success(5);

// Fork with value mappers - always transforms to the target type
Result<string> forked = result.Fork(
    value => value > 0,           // Condition
    value => $"Positive: {value}", // onTrue
    value => $"Non-positive: {value}" // onFalse
);
// forked.Value will be "Positive: 5"

// Fork with different conditions
Result<string> forkedFalse = result.Fork(
    value => value > 10,          // Condition is false
    value => $"Greater than 10: {value}",
    value => $"Not greater than 10: {value}"
);
// forkedFalse.Value will be "Not greater than 10: 5"

// Fork with Result-returning functions
Result<string> forkedWithResults = result.Fork(
    value => value > 0,
    value => Result.Success($"Valid: {value}"),
    value => Result.Failure<string>(new ErrorMessage("validation", "Invalid value"))
);
// If true path returns Failure, the overall Result becomes Failure

// Fork with bool condition instead of function
Result<string> forkedBool = result.Fork(
    true,                          // Static condition
    value => $"True branch: {value}",
    value => $"False branch: {value}"
);
// forkedBool.Value will be "True branch: 5"

// Fork with Func<bool> condition
Result<string> forkedFunc = result.Fork(
    () => DateTime.Now.Hour > 12,  // Condition function
    value => $"Afternoon: {value}",
    value => $"Morning: {value}"
);

// Fork with async mappers
Result<string> forkedAsync = await result.Fork(
    value => value > 0,
    async value => await FormatAsync(value, "positive"),
    async value => await FormatAsync(value, "non-positive")
);

// Fork with mixed async/sync mappers
Result<string> forkedMixed = await result.Fork(
    value => value > 0,
    async value => await FormatAsync(value), // onTrue is async
    value => $"Non-positive: {value}"         // onFalse is sync
);

// Fork on a non-ValueResult
Result result = Result.Success();
Result<string> forkedFromResult = result.Fork(
    true,
    () => "Success path",
    () => "Failure path"
);
// forkedFromResult.Value will be "Success path"
```
#### Tap
On Success, performs a side effect (non-mutating action) and returns the original Result unchanged. Useful for logging, validation, or other side effects.
```csharp
Result<int> result = Result.Success(1);

// Tap with an Action
result.Tap(value => Console.WriteLine(value));
// Prints 1, returns the original Result unchanged

// Tap with an async Action
await result.Tap(async value => await LogAsync(value));

// Tap with a Result-returning function (can perform validation)
Result<int> tappedWithValidation = result.Tap(value => 
    value > 0 
        ? Result.Success() 
        : Result.Failure(new ErrorMessage("validation", "Value must be positive")));
// If validation fails, tappedWithValidation will be Failure

// Tap on a non-ValueResult
Result result = Result.Success();
result.Tap(() => Console.WriteLine("Success!"));
// Prints "Success!", returns the original Result

// Tap with a function that returns a value (value is ignored)
result.Tap(value => SomeFunction(value));
// The return value of SomeFunction is ignored
```
#### TapIf
On Success, if the condition is met, performs a side effect and returns the original Result unchanged. If condition is not met, returns the original Result without performing the action.
```csharp
Result<int> result = Result.Success(1);

// Tap if condition is true
result.TapIf(value => value > 0, value => Console.WriteLine(value));
// Prints 1 (condition was true), returns original Result

// Condition not met - no action performed
result.TapIf(value => value > 10, value => Console.WriteLine(value));
// Nothing is printed (condition was false), returns original Result

// Tap with async condition and action
await result.TapIf(
    async value => await Task.FromResult(value > 0),
    async value => await LogAsync(value)
);

// Tap with a Result-returning function for validation
Result<int> tappedWithValidation = result.TapIf(
    value => value > 0,
    value => Result.Success() // or perform validation
);
```
#### Resolve
On either Success or Failure, resolves the Result into a single value by providing handlers for both cases.
```csharp
Result<int> result = Result.Success(1);

// Resolve with functions
int resolvedValue = result.Resolve(
    success => success,      // On success, return the value
    failure => -1            // On failure, return -1
);
// resolvedValue will be 1

// Resolve with constant values
int resolvedWithConstants = result.Resolve(
    success: 100,
    failure: -1
);
// resolvedWithConstants will be 100 (success case)

// Resolve with different return types
string resolvedToString = result.Resolve(
    success => $"Value: {success}",
    failure => "Error occurred"
);
// resolvedToString will be "Value: 1"

// Resolve with async handlers
string resolvedAsync = await result.Resolve(
    async success => await FormatAsync(success),
    async failure => await GetErrorMessageAsync(failure)
);

// Resolve on a non-ValueResult
Result result = Result.Success();
string message = result.Resolve(
    success: "Operation succeeded",
    failure: "Operation failed"
);
// message will be "Operation succeeded"
```
#### Side
On Success, performs a non-essential action. The Result of that action will not change the Result of the main pipeline. Instead, if the side action fails, its errors will be converted into warnings.
```csharp
Result<int> result = Result.Success(1);

// Side action that succeeds - no effect on main Result
result = result.Side(value => Result.Success());
// result remains Success(1) with no warnings

// Side action that fails - errors become warnings
result = result.Side(value => Result.Failure<int>(new ErrorMessage("errorType", "Error message")));
// result remains Success(1), but now has a warning with the error message

// Side action with async function
result = await result.Side(async value => 
    await SomeNonEssentialOperationAsync(value));

// Side action on a non-ValueResult
Result result = Result.Success();
result = result.Side(() => Result.Failure(new ErrorMessage("warning", "Non-critical issue")));
// result remains Success(), but has a warning
```
#### Ensure
Checks a condition and changes the Result accordingly. If the condition is false, the Result becomes a Failure with the provided error.
```csharp
Result<int> result = Result.Success(1);

// Ensure with a boolean condition
result = result.Ensure(value => value > 0, new ErrorMessage("errorType", "Value must be greater than 0"));
// result remains Success(1) because condition is true

// Condition fails - Result becomes Failure
result = result.Ensure(value => value > 10, new ErrorMessage("errorType", "Value must be greater than 10"));
// result is now Failure with the error message

// Ensure with a function returning boolean
result = Result.Success(5);
result = result.Ensure(() => SomeValidation(), new ErrorMessage("errorType", "Validation failed"));

// Ensure with an async condition
result = await result.Ensure(
    async value => await ValidateAsync(value),
    new ErrorMessage("errorType", "Async validation failed")
);

// Ensure on a non-ValueResult
Result result = Result.Success();
result = result.Ensure(() => true, new ErrorMessage("errorType", "Condition failed"));
// If condition is false, result becomes Failure
```
#### Compel
On Failure, throws a `FailureResultException` with the error messages. Use this when you want to convert a Failure Result into an exception.
```csharp
Result<int> result = Result.Failure<int>(new ErrorMessage("errorType", "Error message"));

// Throws FailureResultException with the errors
result.Compel();
// Will throw an exception containing the error messages

// Compel with a custom exception factory
result.Compel(errors => new CustomException($"Operation failed: {errors.First().Message}"));

// Compel on a non-ValueResult
Result result = Result.Failure(new ErrorMessage("error", "Something went wrong"));
result.Compel();
// Throws FailureResultException
```
#### Suppress
Removes errors of a specified type. If all errors are suppressed and the Result was a Failure, it becomes a Success. If it was already a Success, it remains Success.
```csharp
Result<int> result = Result.Failure<int>(
    new ErrorMessage("errorType", "Error message"),
    new ErrorMessage("otherType", "Another error")
);

// Suppress errors of a specific type
Result newResult = result.Suppress("errorType");
// newResult still has the "otherType" error

// If all errors are suppressed, Result becomes Success
Result allSuppressed = result.Suppress("errorType", "otherType");
// allSuppressed.IsSuccess will be true

// Suppress on a Success Result
Result success = Result.Success(1);
Result stillSuccess = success.Suppress("errorType");
// stillSuccess remains Success(1)
```
#### HandleError
Removes errors of a specified type and allows a callback to handle them. The callback can return a new Result to replace the handled errors, or perform side effects.
```csharp
Result<int> result = Result.Failure<int>(new ErrorMessage("errorType", "Error message"));

// Handle error with an Action (performs side effect, removes error)
Result newResult = result.HandleError("errorType", errors => Console.WriteLine(errors.First().Message));
// Error is logged and removed, newResult may become Success if no other errors remain

// Handle error with a function returning Result (can replace error with new Result)
Result handledWithResult = result.HandleError("errorType", errors => 
{
    Console.WriteLine("Handling error...");
    return Result.Success(); // Replace error with Success
});

// Handle error with a function that returns a value (ignored, error is still removed)
result.HandleError("errorType", errors => 
{
    LogError(errors);
    return 0; // Return value is ignored
});

// Handle error with async callback
Result handledAsync = await result.HandleError("errorType", async errors => 
{
    await LogToDatabaseAsync(errors);
    return Result.Success();
});
```
#### OnError
On Failure with a specific error type, performs a side effect without changing the Result. The original Result is preserved unchanged, but errors can be added if the callback returns a Result with errors. Similar to `Tap` but for errors - useful for logging or performing actions when specific errors occur without interrupting the chain.
```csharp
Result<int> result = Result.Failure<int>(new ErrorMessage("errorType", "Error message"));

// OnError with an Action - logs when specific error occurs
result = result.OnError("errorType", errors => Console.WriteLine(errors.First().Message));
// Prints the error message, returns the original Failure Result unchanged

// OnError with a function returning Result - can add errors but preserves original
result = result.OnError("errorType", errors => 
{
    LogToDatabase(errors);
    return Result.Failure(new ErrorMessage("AdditionalError", "Something else went wrong"));
});
// Original errors are preserved, additional errors are combined

// OnError with async action
result = await result.OnError("errorType", async errors => 
{
    await LogToDatabaseAsync(errors);
});
// Logs asynchronously, returns original Result unchanged

// OnError with a function returning Result that succeeds
result = result.OnError("errorType", errors => 
{
    LogError(errors);
    return Result.Success();
});
// Original errors are preserved, no new errors added

// OnError on a non-ValueResult
Result result = Result.Failure(new ErrorMessage("errorType", "Something went wrong"));
result = result.OnError("errorType", errors => Logger.LogError(errors));
// Logs the error, returns original Failure Result unchanged

// OnError only executes if error type matches
Result result = Result.Failure(new ErrorMessage("otherError", "Different error"));
result = result.OnError("errorType", errors => Console.WriteLine("This won't execute"));
// Callback doesn't execute because error type doesn't match
```
#### HandleWarning
Removes warnings of a specified type and allows a callback to handle them. Useful for processing warnings before removing them.
```csharp
Result<int> result = Result.Success(1).Warn(new WarningMessage("warningType", "Warning message"));

// Handle warning with an Action
result = result.HandleWarning("warningType", warnings => Console.WriteLine(warnings.First().Message));
// Warning is logged and removed, result remains Success(1) without warnings

// Handle warning with a function
result = result.HandleWarning("warningType", warnings => 
{
    foreach (var warning in warnings)
    {
        Logger.LogWarning(warning);
    }
});

// Handle warning with async callback
result = await result.HandleWarning("warningType", async warnings => 
{
    await ProcessWarningsAsync(warnings);
});
```
#### Warn
Adds a warning message to a successful Result. Warnings do not cause the Result to fail, but can be processed or logged separately.
```csharp
Result<int> result = Result.Success(1);

// Add a single warning
result = result.Warn(new WarningMessage("warningType", "Warning message"));
// result remains Success(1), but now has a warning

// Add multiple warnings
result = result.Warn(
    new WarningMessage("warning1", "First warning"),
    new WarningMessage("warning2", "Second warning")
);

// Warn on a non-ValueResult
Result result = Result.Success();
result = result.Warn(new WarningMessage("info", "Operation completed with warnings"));
```
#### WarnIf
Adds a warning message if the condition is met. If the condition is false, no warning is added.
```csharp
Result<int> result = Result.Success(1);

// Add warning if condition is true
result = result.WarnIf(value => value > 0, new WarningMessage("warningType", "Warning message"));
// Warning is added because value > 0 is true

// Condition is false - no warning added
result = result.WarnIf(value => value > 10, new WarningMessage("warningType", "Value is high"));
// No warning added because condition is false

// WarnIf with a function returning boolean
result = result.WarnIf(() => SomeCondition(), new WarningMessage("warningType", "Warning message"));

// WarnIf with async condition
result = await result.WarnIf(
    async value => await ShouldWarnAsync(value),
    new WarningMessage("warningType", "Warning message")
);

// WarnIf on a non-ValueResult
Result result = Result.Success();
result = result.WarnIf(() => true, new WarningMessage("info", "Condition met"));
```
#### Roll
Combines multiple ValueResults into a tuple. Useful for collecting multiple values from independent operations. Supports chaining up to 17 values. If any result fails, returns failure with those errors.
```csharp
Result<int> result1 = Result.Success(1);
Result<string> result2 = Result.Success("hello");
Result<bool> result3 = Result.Success(true);

// Combines into a tuple
Result<(int, string, bool)> combined = result1.Roll(result2).Roll(result3);
// combined.Value will be (1, "hello", true)

// Also supports Task variants
Result<(int, string)> combinedAsync = await result1.Roll(Task.FromResult(result2));
```
#### Map (Tuple Deconstruction)
Generated Map extensions allow deconstructing tuples from Roll results. Instead of accessing tuple items manually, you can map with a function that takes the tuple elements as separate parameters. Supports tuples from 2 to 16 elements.
```csharp
Result<int> result1 = Result.Success(1);
Result<string> result2 = Result.Success("hello");
Result<bool> result3 = Result.Success(true);

// Roll into a tuple
Result<(int, string, bool)> rolled = result1.Roll(result2).Roll(result3);

// Map with tuple deconstruction - function receives individual elements
Result<string> mapped = rolled.Map((intValue, stringValue, boolValue) => 
    $"{intValue} - {stringValue} - {boolValue}");
// mapped.Value will be "1 - hello - True"

// Map with a Result-returning function
Result<int> mappedWithResult = rolled.Map((intValue, stringValue, boolValue) => 
    boolValue 
        ? Result.Success(intValue + stringValue.Length) 
        : Result.Failure<int>(new ErrorMessage("validation", "Boolean must be true")));

// Works with any tuple size from Roll
Result<int> r1 = Result.Success(1);
Result<string> r2 = Result.Success("two");
Result<bool> r3 = Result.Success(true);
Result<double> r4 = Result.Success(4.0);

Result<(int, string, bool, double)> rolled4 = r1.Roll(r2).Roll(r3).Roll(r4);
Result<string> mapped4 = rolled4.Map((a, b, c, d) => $"{a}{b}{c}{d}");
// mapped4.Value will be "1twoTrue4"
```
#### MapAll
Maps over each element in a `Result<IEnumerable<TValue>>` collection. Applies a mapper function to each element and returns `Result<IEnumerable<TMappedValue>>`. If the input Result is a failure, returns failure. If any element mapping fails, returns failure with all errors collected.
```csharp
Result<IEnumerable<int>> result = Result.Success(new[] { 1, 2, 3 }.AsEnumerable());

// Map with a simple function
Result<IEnumerable<string>> mapped = result.MapAll(x => x.ToString());
// mapped.Value will be ["1", "2", "3"]

// Map to a different type
Result<IEnumerable<string>> mappedToString = result.MapAll(x => $"Value: {x}");
// mappedToString.Value will be ["Value: 1", "Value: 2", "Value: 3"]

// Map with a Result-returning function (can fail for individual elements)
Result<IEnumerable<string>> mappedWithResult = result.MapAll(x => 
    x > 0 
        ? Result.Success($"Value: {x}") 
        : Result.Failure<string>(new ErrorMessage("validation", "Value must be positive")));
// If any element mapping fails, all errors are collected

// Map with async function
Result<IEnumerable<string>> mappedAsync = await result.MapAll(async x => 
    await Task.FromResult(x.ToString()));

// Map with async Result-returning function
Result<IEnumerable<string>> mappedAsyncWithResult = await result.MapAll(async x => 
    await Task.FromResult(Result.Success($"Value: {x}")));

// Supports Task<Result<IEnumerable<TValue>>>
Task<Result<IEnumerable<int>>> resultTask = Task.FromResult(result);
Result<IEnumerable<string>> mappedTask = await resultTask.MapAll(x => x.ToString());

// Empty collection
Result<IEnumerable<int>> emptyResult = Result.Success(Array.Empty<int>().AsEnumerable());
Result<IEnumerable<string>> mappedEmpty = emptyResult.MapAll(x => x.ToString());
// mappedEmpty.Value will be an empty collection
```
#### TapAll
Performs side effects on each element in a `Result<IEnumerable<TValue>>` collection and returns the original Result unchanged. If the input Result is a failure, no side effects are performed. If any element tap fails, returns failure with all errors collected.
```csharp
Result<IEnumerable<int>> result = Result.Success(new[] { 1, 2, 3 }.AsEnumerable());

// Tap with an Action
var tappedValues = new List<int>();
Result<IEnumerable<int>> tapped = result.TapAll(x => tappedValues.Add(x));
// tapped.Value will be [1, 2, 3], tappedValues will also contain [1, 2, 3]
// The original Result is returned unchanged

// Tap with a Result-returning function (can perform validation)
Result<IEnumerable<int>> tappedWithValidation = result.TapAll(x => 
    x > 0 
        ? Result.Success() 
        : Result.Failure(new ErrorMessage("validation", "Value must be positive")));
// If any validation fails, tappedWithValidation will be Failure with all errors collected

// Tap with async Action
Result<IEnumerable<int>> tappedAsync = await result.TapAll(async x => 
    await LogAsync(x));
// Logs each value, returns original Result unchanged

// Tap with async Result-returning function
Result<IEnumerable<int>> tappedAsyncWithValidation = await result.TapAll(async x => 
    await ValidateAsync(x));

// Supports Task<Result<IEnumerable<TValue>>>
Task<Result<IEnumerable<int>>> resultTask = Task.FromResult(result);
Result<IEnumerable<int>> tappedTask = await resultTask.TapAll(x => Console.WriteLine(x));

// Empty collection
Result<IEnumerable<int>> emptyResult = Result.Success(Array.Empty<int>().AsEnumerable());
Result<IEnumerable<int>> tappedEmpty = emptyResult.TapAll(x => Console.WriteLine(x));
// No side effects performed, returns original empty Result
```
#### Combine (Extension)
Extension methods for combining collections of Results. Works with IEnumerable and Task combinations for more complex scenarios.
```csharp
Result result1 = Result.Success();
Result result2 = Result.Success();
Result<int> valueResult1 = Result.Success(1);
Result<int> valueResult2 = Result.Success(2);

// Combine IEnumerable of Results
var results = new List<Result> { result1, result2 };
Result combinedEnumerable = results.Combine();

// Combine IEnumerable of ValueResults
var valueResults = new List<Result<int>> { valueResult1, valueResult2 };
Result<IEnumerable<int>> combinedValueEnumerable = valueResults.Combine();

// Supports Task combinations
Task<IEnumerable<Result<int>>> resultsTask = Task.FromResult(valueResults);
Result<IEnumerable<int>> combinedTask = await resultsTask.Combine();

// Supports IEnumerable<Task<Result<TValue>>>
var resultTasks = new List<Task<Result<int>>>
{
    Task.FromResult(valueResult1),
    Task.FromResult(valueResult2)
};
Result<IEnumerable<int>> combinedTaskEnumerable = await resultTasks.Combine();

// Supports Task<IEnumerable<Task<Result<TValue>>>>
Task<IEnumerable<Task<Result<int>>>> nestedTask = Task.FromResult(resultTasks);
Result<IEnumerable<int>> combinedNested = await nestedTask.Combine();
```