using AoC2021Core;

namespace AoC2021Days
{
    public class Day01 : IDay
    {
        private static readonly List<int> InputList =
            ReadInput.ConvertInputTextToIntList(@"..\..\..\..\Inputs\Day01.txt");

        public void SolvePartOne()
        {
            Console.WriteLine("Day 1 - Part 1");
            if (InputList.Count == 0) return;

            var measurementCounts = 0;
            for (int i = 1; i < InputList.Count; i++)
            {
                if (InputList[i] > InputList[i - 1]) measurementCounts++;
            }

            Console.WriteLine(measurementCounts);
        }

        public void SolvePartTwo()
        {
            Console.WriteLine("Day 1 - Part 2");
            if (InputList.Count == 0) return;

            int sumListLength = InputList.Count - 2;
            int[] sumList = new int[sumListLength];
            for (int i = 0; i < sumListLength; i++)
            {
                sumList[i] = InputList[i] + InputList[i + 1] + InputList[i + 2];
            }

            var sumMeasurementCount = 0;
            for (int i = 1; i < sumListLength; i++)
            {
                if (sumList[i] > sumList[i - 1]) sumMeasurementCount++;
            }

            Console.WriteLine(sumMeasurementCount);
        }
    }
}