namespace Developist.Core.ArgumentValidation;

/// <summary>
/// Provides a centralized, static instance for argument validation.
/// </summary>
/// <remarks>
/// This class serves as an entry point to a suite of argument validation methods defined in <see cref="EnsureArgumentExtensions"/>.
/// </remarks>
public static class Ensure
{
    /// <summary>
    /// The static instance of <see cref="IEnsureArgument"/> used for argument validation.
    /// </summary>
    public static readonly IEnsureArgument Argument = new EnsureArgument();

    private class EnsureArgument : IEnsureArgument
    {
    }
}
