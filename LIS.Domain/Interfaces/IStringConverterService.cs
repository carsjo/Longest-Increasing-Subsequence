namespace LIS.Domain.Interfaces;

public interface IStringConverterService
{
    string[] ParseStringToStringArray(string? inputSequence);
}