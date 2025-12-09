using LIS.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LIS.Domain.Services;

public sealed class StringConverterService(
    ILogger<StringConverterService> logger) : IStringConverterService
{
    public string[] ParseStringToStringArray(string? inputSequence)
    {
        if (string.IsNullOrWhiteSpace(inputSequence))
        {
            logger.LogError("Input string was null or empty.");
            return [];
        }

        var outputSequence = inputSequence.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        logger.LogInformation("Parsed string to array with {Length} items.", outputSequence.Length);
        return outputSequence;
    }
}