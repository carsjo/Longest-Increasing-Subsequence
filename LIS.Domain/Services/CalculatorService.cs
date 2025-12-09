using LIS.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace LIS.Domain.Services
{
    public sealed class CalculatorService(
        ILogger<CalculatorService> logger,
        IStringConverterService stringConverterService) : ICalculatorService
    {
        public ArraySegment<int> ComputeLongestIncreasingSubsequence(string inputSequence)
        {
            try
            {
                var stringArr = stringConverterService.ParseStringToStringArray(inputSequence);
                if (stringArr.Length is 0)
                {
                    logger.LogWarning("Empty string array");
                    return ArraySegment<int>.Empty;
                }

                // int array will never be empty here
                var intArr = Array.ConvertAll(stringArr, int.Parse);

                var maxLength = 0;
                var maxStartIndex = 0;
                var currentStartIndex = 0;
                var currentLength = 1;

                for (var i = 1; i < intArr.Length; i++)
                {
                    if (intArr[i] > intArr[i - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        SetCurrentIfGreaterThanMax();

                        currentStartIndex = i;
                        currentLength = 1;
                    }
                }

                SetCurrentIfGreaterThanMax();

                return new ArraySegment<int>(intArr, maxStartIndex, maxLength);

                void SetCurrentIfGreaterThanMax()
                {
                    if (currentLength <= maxLength)
                    {
                        return;
                    }
                    maxLength = currentLength;
                    maxStartIndex = currentStartIndex;
                }
            }
            catch (Exception ex) when (ex is FormatException or OverflowException or ArgumentNullException or ArgumentOutOfRangeException or ArgumentException)
            {
                // Will never naturally trigger any exception from the ArraySegment constructor because:
                //  *   maxStartIndex and maxLength are always kept within valid bounds by the algorithm
                //  *   The algorithm only increments indices within the array length
                logger.LogError(ex, "An exception occured during calculation");
                return ArraySegment<int>.Empty;
            }
        }
    }
}
