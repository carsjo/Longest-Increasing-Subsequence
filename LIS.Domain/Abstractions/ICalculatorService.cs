namespace LIS.Domain.Abstractions;

public interface ICalculatorService
{
    ArraySegment<int> ComputeLongestIncreasingSubsequence(string inputSequence);
}
