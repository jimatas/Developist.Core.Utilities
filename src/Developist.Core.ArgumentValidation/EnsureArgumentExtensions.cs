namespace Developist.Core.ArgumentValidation;

/// <summary>
/// Provides extension methods for argument validation.
/// </summary>
public static class EnsureArgumentExtensions
{
    /// <summary>
    /// Ensures that the provided value is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to check.</typeparam>
    /// <param name="_">The extension method placeholder, not used.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The non-null value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the value is <see langword="null"/>.</exception>
    public static T NotNull<T>(this IEnsureArgument _,
        [NotNull] T? value,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        return value ?? throw new ArgumentNullException(paramName);
    }

    /// <summary>
    /// Ensures that the provided string is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="ensureArgument">The extension method placeholder.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The non-null and non-empty string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the string is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when the string is empty.</exception>
    public static string NotNullOrEmpty(this IEnsureArgument ensureArgument,
        [NotNull] string? value,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        ensureArgument.NotNull(value, paramName);

        if (value.Length == 0)
        {
            throw new ArgumentException(message: "Value cannot be an empty string.", paramName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided nullable Guid value is not <see langword="null"/> and not an empty Guid.
    /// </summary>
    /// <param name="ensureArgument">The extension method placeholder.</param>
    /// <param name="value">The nullable Guid value to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The non-null and non-empty Guid value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the value is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when the value is an all-zero Guid.</exception>
    [return: NotNull]
    public static Guid? NotNullOrEmpty(this IEnsureArgument ensureArgument,
        [NotNull] Guid? value,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        ensureArgument.NotNull(value, paramName);

        if (value.Equals(Guid.Empty))
        {
            throw new ArgumentException(message: "Value cannot be an all-zero GUID.", paramName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided enumerable is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="ensureArgument">The extension method placeholder.</param>
    /// <param name="value">The enumerable to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The non-null and non-empty enumerable.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the enumerable is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when the enumerable is empty.</exception>
    public static IEnumerable<T> NotNullOrEmpty<T>(this IEnsureArgument ensureArgument,
        [NotNull] IEnumerable<T>? value,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        ensureArgument.NotNull(value, paramName);

        if (!value.Any())
        {
            throw new ArgumentException(message: "Collection must contain at least one element.", paramName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided string is not <see langword="null"/>, empty, or consists only of whitespace characters.
    /// </summary>
    /// <param name="ensureArgument">The extension method placeholder.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The non-null, non-empty, and non-whitespace string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the string is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when the string is empty or whitespace.</exception>
    public static string NotNullOrWhiteSpace(this IEnsureArgument ensureArgument,
        [NotNull] string? value,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        ensureArgument.NotNullOrEmpty(value, paramName);

        if (value.All(char.IsWhiteSpace))
        {
            throw new ArgumentException(message: "Value cannot be composed entirely of whitespace.", paramName);
        }

        return value;
    }

    /// <summary>
    /// Ensures that the provided value is within the specified range.
    /// </summary>
    /// <typeparam name="T">The type of the value to check. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="_">The extension method placeholder, not used.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="minValue">The minimum value of the range. If <see langword="null"/>, no minimum limit is imposed.</param>
    /// <param name="maxValue">The maximum value of the range. If <see langword="null"/>, no maximum limit is imposed.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The value if it is within the specified range.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is less than the specified minimum or greater than the specified maximum.</exception>
    public static T NotOutOfRange<T>(this IEnsureArgument _,
        T value,
        IComparable<T>? minValue = default,
        IComparable<T>? maxValue = default,
        [CallerArgumentExpression("value")] string? paramName = default)
    {
        if ((minValue is not null && minValue.CompareTo(value) > 0) ||
            (maxValue is not null && maxValue.CompareTo(value) < 0))
        {
            throw new ArgumentOutOfRangeException(paramName, actualValue: value,
                message: BuildOutOfRangeExceptionMessage(minValue, maxValue));
        }

        return value;
    }

    private static string BuildOutOfRangeExceptionMessage(object? minValue, object? maxValue)
    {
        return "Value must be " +
            (minValue is not null && maxValue is not null
                ? $"between {minValue} and {maxValue}, inclusive."
                : minValue is not null
                    ? $"greater than or equal to {minValue}."
                    : $"less than or equal to {maxValue}.");
    }

    /// <summary>
    /// Ensures that the provided enum value is a defined value within the enum type.
    /// </summary>
    /// <typeparam name="T">The enum type. Must be a <see langword="struct"/> and an <see cref="Enum"/>.</typeparam>
    /// <param name="_">The extension method placeholder, not used.</param>
    /// <param name="value">The enum value to check.</param>
    /// <param name="paramName">The name of the parameter to check. This is automatically provided.</param>
    /// <returns>The enum value if it is defined within the enum type.</returns>
    /// <exception cref="InvalidEnumArgumentException">Thrown when the provided value is not a defined value within the enum type.</exception>
    public static T NotInvalidEnum<T>(this IEnsureArgument _,
        T value,
        [CallerArgumentExpression("value")] string? paramName = default) where T : struct, Enum
    {
        if (!Enum.IsDefined(typeof(T), value))
        {
            throw new InvalidEnumArgumentException(paramName,
                invalidValue: Convert.ToInt32(value),
                enumClass: typeof(T));
        }

        return value;
    }
}
