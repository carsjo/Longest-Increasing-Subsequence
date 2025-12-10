namespace LIS.Domain.Abstractions;

public interface IStringConverterService
{
    string[] ParseStringToStringArray(string? inputSequence);
}