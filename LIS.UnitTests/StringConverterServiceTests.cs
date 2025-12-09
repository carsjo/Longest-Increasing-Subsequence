using LIS.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace LIS.UnitTests;

public sealed class StringConverterServiceTests : MockTestBase<StringConverterService>
{
    private readonly StringConverterService _sut;

    public StringConverterServiceTests()
        => _sut = new StringConverterService(MockLogger);

    [Fact]
    public void ParseStringToStringArray_WhenGivenNull_ShouldReturnEmptyArray()
    {
        var actual = _sut.ParseStringToStringArray(null);

        Assert.Empty(actual);

        AssertThatLogShouldHave(LogLevel.Error, "Input string was null or empty.", Times.Once());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    public void ParseStringToStringArray_WhenGivenEmpty_ShouldReturnEmptyArray(string inputSequence)
    {
        var actual = _sut.ParseStringToStringArray(inputSequence);

        Assert.Empty(actual);

        AssertThatLogShouldHave(LogLevel.Error, "Input string was null or empty.", Times.Once());
    }

    [Theory]
    [InlineData("1 a   b 1", new[]
    {
        "1",
        "a",
        "b",
        "1"
    })]
    [InlineData("1 1   1 1", new[]
    {
        "1",
        "1",
        "1",
        "1"
    })]
    [InlineData(" 1 1 1 1 ", new[]
    {
        "1",
        "1",
        "1",
        "1"
    })]
    public void ParseStringToStringArray_WhenGivenValidString_ShouldReturnExpected(
        string? inputSequence, string[] expected)
    {
        var actual = _sut.ParseStringToStringArray(inputSequence);

        Assert.Equal(expected, actual);

        AssertThatLogShouldHave(LogLevel.Information, $"Parsed string to array with {expected.Length} items.", Times.Once());
    }
}