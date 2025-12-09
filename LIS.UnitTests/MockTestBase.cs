using Microsoft.Extensions.Logging;
using Moq;

namespace LIS.UnitTests;

public abstract class MockTestBase<TCategoryName> where TCategoryName : notnull
{
    private readonly Mock<ILogger<TCategoryName>> _mockLogger = new();
    protected ILogger<TCategoryName> MockLogger => _mockLogger.Object;

    protected MockTestBase()
        => _mockLogger
            .Setup(x => x.IsEnabled(It.IsAny<LogLevel>()))
            .Returns(true);

    protected void AssertThatLogShouldHave(LogLevel logLevel, string containsMessage, Times times) =>
        _mockLogger
            .Verify(x => x.Log(logLevel,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, _) => (o.ToString() ?? "").Contains(containsMessage, StringComparison.InvariantCulture)),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()), times);
}