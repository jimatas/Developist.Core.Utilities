
# Developist.Core.Utilities

A collection of general utilities that are usable in .NET 5.0 projects. For now, the main functionality provided consists of a standard set of guard clauses for the purpose of precondition checking.

## Ensure.Argument

The guard clauses are implemented as extension methods on the `IEnsureArgument` interface. An instance of a class that implements that interface is exposed through the static read-only `Argument` field of the static `Ensure` class, allowing for the following syntax when calling the guard clauses.

```csharp
Ensure.Argument.NotNull(aParameter, nameof(aParameter));
Ensure.Argument.NotNull(() => aParameter);
Ensure.Argument.NotNullOrEmpty(anotherParameter, nameof(anotherParameter), "The parameter cannot be null or empty!");
// etc...
```

The previous example shows some of the commonly used guard clauses that are provided through the `EnsureArgumentExtensions` class. Additional guards can be added in the manner described earlier. That is, by defining an appropriate extension method on the `IEnsureArgument` interface.

## Examples

Sample precondition checks using guard clauses inside a method.

```csharp
public void SomeSampleMethod(string name, int age)
{
    // name is required to have some sort of 'printable' value.
    Ensure.Argument.NotNullOrWhiteSpace(name, nameof(name));
    // age >= 18
    Ensure.Argument.NotOutOfRange(age, nameof(age), lowerBound: 18);
    // ... rest of method
}
```

Or as a precondition check and field assignment in one, in the following constructor.

```csharp
public SomeSampleClass(SomeSampleDependency arg)
{
    this.safeValue = Ensure.Argument.NotNull(arg, nameof(arg));
}
 ```
 
Note that all the built-in guard clauses will return the supplied value if the check succeeds and an exception is not thrown.
