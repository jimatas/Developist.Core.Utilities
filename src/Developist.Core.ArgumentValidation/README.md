# Developist.Core.ArgumentValidation

This library offers a set of fluent extension methods for argument validation in .NET applications.

## Features

The [`Ensure`](Ensure.cs) class simplifies the usage of argument validation methods by offering a single, static instance of [`IEnsureArgument`](IEnsureArgument.cs), which allows for a fluent and consistent syntax.
It includes methods for common validations like `NotNull`, `NotNullOrEmpty`, `NotNullOrWhiteSpace`, and `NotOutOfRange`.

### Sample Usage

The following example illustrates the usage of the [`Ensure`](Ensure.cs) class for argument validation:

```csharp
public class CustomerService
{
    private readonly string _apiKey;

    public CustomerService(string apiKey)
    {
        _apiKey = Ensure.Argument.NotNullOrWhiteSpace(apiKey);
    }

    public void RegisterCustomer(Customer customer)
    {
        Ensure.Argument.NotNull(customer);
        
        // Additional method logic using the non-null Customer instance here.
    }
}
```
