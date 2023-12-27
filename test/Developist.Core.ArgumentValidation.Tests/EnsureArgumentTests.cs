namespace Developist.Core.ArgumentValidation.Tests;

[TestClass]
public class EnsureArgumentTests
{
    [DataTestMethod]
    [DynamicData(nameof(NonNullValues))]
    public void NotNull_GivenNonNullValue_ReturnsValue(object value)
    {
        // Arrange

        // Act
        object returnValue = Ensure.Argument.NotNull(value);

        // Assert
        Assert.AreEqual(value, returnValue);
    }

    public static IEnumerable<object[]> NonNullValues
    {
        get
        {
            yield return new object[] { new() };
            yield return new object[] { string.Empty };
            yield return new object[] { Guid.Empty };
            yield return new object[] { 0 };
        }
    }

    [TestMethod]
    public void NotNull_GivenNullValue_ThrowsArgumentNullException()
    {
        // Arrange
        object? value = null;

        // Act
        void action() => Ensure.Argument.NotNull(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentNullException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNonNullOrEmptyString_ReturnsString()
    {
        // Arrange
        string? value = "Non-null, non-empty string";
        string returnValue;

        // Act
        returnValue = Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        Assert.AreEqual(value, returnValue);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNullString_ThrowsArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentNullException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenEmptyString_ThrowsArgumentException()
    {
        // Arrange
        string? value = string.Empty;

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be an empty string."));
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNonNullOrEmptyGuid_ReturnsGuid()
    {
        // Arrange
        Guid? value = Guid.NewGuid();

        // Act
        Guid? returnedValue = Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        Assert.AreEqual(value, returnedValue);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNullGuid_ThrowsArgumentNullException()
    {
        // Arrange
        Guid? value = null;

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentNullException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenEmptyGuid_ThrowsArgumentException()
    {
        // Arrange
        var value = Guid.Empty;

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be an all-zero GUID."));
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNonNullEnumerable_ReturnsEnumerable()
    {
        // Arrange
        IEnumerable<object>? value = new object[] { new(), new() };
        IEnumerable<object> returnValue;

        // Act
        returnValue = Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        Assert.AreEqual(value, returnValue);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenNullEnumerable_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<object>? value = null;

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentNullException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }

    [TestMethod]
    public void NotNullOrEmpty_GivenEmptyEnumerable_ThrowsArgumentException()
    {
        // Arrange
        IEnumerable<object>? value = Enumerable.Empty<object>();

        // Act
        void action() => Ensure.Argument.NotNullOrEmpty(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith("Collection must contain at least one element."));
    }

    [TestMethod]
    public void NotNullOrWhiteSpace_GivenNonNullOrWhiteString_ReturnsString()
    {
        // Arrange
        string? value = "Non-null, non-whitespace string";
        string returnValue;

        // Act
        returnValue = Ensure.Argument.NotNullOrWhiteSpace(value);

        // Assert
        Assert.AreEqual(value, returnValue);
    }

    [TestMethod]
    public void NotNullOrWhiteSpace_GivenNullString_ThrowsArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act
        void action() => Ensure.Argument.NotNullOrWhiteSpace(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentNullException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }

    [TestMethod]
    public void NotNullOrWhiteSpace_GivenEmptyString_ThrowsArgumentException()
    {
        // Arrange
        string? value = string.Empty;

        // Act
        void action() => Ensure.Argument.NotNullOrWhiteSpace(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be an empty string."));
    }

    [TestMethod]
    public void NotNullOrWhiteSpace_GivenWhiteSpaceString_ThrowsArgumentException()
    {
        // Arrange
        string? value = "\r\n\t";

        // Act
        void action() => Ensure.Argument.NotNullOrWhiteSpace(value);

        // Assert
        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith("Value cannot be composed entirely of whitespace."));
    }

    [DataTestMethod]
    [DataRow(1, 0)]
    [DataRow(0, 0)]
    public void NotOutOfRange_GivenValueGreaterOrEqualToMinValue_ReturnsValue(int value, int minValue)
    {
        // Arrange

        // Act
        var returnedValue = Ensure.Argument.NotOutOfRange(value, minValue: minValue);

        // Assert
        Assert.AreEqual(value, returnedValue);
    }

    [DataTestMethod]
    [DataRow(0.0, 1.0)]
    [DataRow(1.0, 1.0)]
    public void NotOutOfRange_GivenValueLessThanOrEqualToMaxValue_ReturnsValue(double value, double maxValue)
    {
        // Arrange

        // Act
        var returnedValue = Ensure.Argument.NotOutOfRange(value, maxValue: maxValue);

        // Assert
        Assert.AreEqual(value, returnedValue);
    }

    [TestMethod]
    public void NotOutOfRange_GivenValueLessThanMinValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const int value = -1;
        const int minValue = 0;

        // Act
        static void action() => Ensure.Argument.NotOutOfRange(value, minValue: minValue);

        // Assert
        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith($"Value must be greater than or equal to {minValue}."));
    }

    [TestMethod]
    public void NotOutOfRange_GivenValueGreaterThanMaxValue_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        const int value = 6;
        const int maxValue = 5;

        // Act
        static void action() => Ensure.Argument.NotOutOfRange(value, maxValue: maxValue);

        // Assert
        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith($"Value must be less than or equal to {maxValue}."));
    }

    [DataTestMethod]
    [DataRow(-1, 0, 2)]
    [DataRow(3, 0, 2)]
    public void NotOutOfRange_GivenValueOutsideOfRange_ThrowsArgumentOutOfRangeException(int value, int minValue, int maxValue)
    {
        // Arrange

        // Act
        void action() => Ensure.Argument.NotOutOfRange(value, minValue, maxValue);

        // Assert
        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
        Assert.IsTrue(exception.Message.StartsWith($"Value must be between {minValue} and {maxValue}, inclusive."));
    }

    [TestMethod]
    public void NotInvalidEnum_GivenValidEnumMember_ReturnsMember()
    {
        // Arrange
        var value = DayOfWeek.Monday;

        // Act
        DayOfWeek returnedValue = Ensure.Argument.NotInvalidEnum(value);

        // Assert
        Assert.AreEqual(value, returnedValue);
    }

    [TestMethod]
    public void NotInvalidEnum_GivenInvalidEnumMember_ThrowsInvalidEnumArgumentException()
    {
        // Arrange
        var value = (DayOfWeek)int.MaxValue;

        // Act
        void action() => Ensure.Argument.NotInvalidEnum(value);

        // Assert
        var exception = Assert.ThrowsException<InvalidEnumArgumentException>(action);
        Assert.AreEqual(nameof(value), exception.ParamName);
    }
}
