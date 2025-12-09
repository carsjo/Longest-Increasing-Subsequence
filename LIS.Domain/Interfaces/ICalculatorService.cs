namespace LIS.Domain.Interfaces
{
    public interface ICalculatorService
    {
        ArraySegment<int> ComputeLongestIncreasingSubsequence(string inputSequence);
    }
}
