using AoC2021Core;
using AoC2021Class.Day09;

namespace AoC2021Days
{
    public class Day09 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day09.txt", "\n");
        private static readonly int[,] ConvertedInput =
            ReadInput.ConvertInputStringListTo2DArray(InputList);
        private static readonly List<Tuple<int, int>> LowPointsList = new();

        public void SolvePartOne()
        {
            int sumRisk = 0;
            for (int lineIndex = 0; lineIndex < ConvertedInput.GetLength(0); lineIndex++)
            {
                for (int rowIndex = 0; rowIndex < ConvertedInput.GetLength(1); rowIndex++)
                {
                    if (MapUtility.LowPointCheck(ConvertedInput, lineIndex, rowIndex))
                    {
                        LowPointsList.Add(new Tuple<int, int>(lineIndex, rowIndex));
                        sumRisk += ConvertedInput[lineIndex, rowIndex] + 1;
                    }
                }
            }
            Console.WriteLine(sumRisk);
        }

        public void SolvePartTwo()
        {
            int[] basinSizes = new int[LowPointsList.Count];
            for (int i = 0; i < LowPointsList.Count; i++)
            {
                basinSizes[i] = MapUtility.BasinSize(ConvertedInput, LowPointsList[i].Item1, LowPointsList[i].Item2);
            }
            Array.Sort(basinSizes);
            Array.Reverse(basinSizes);
            Console.WriteLine(basinSizes[0] * basinSizes[1] * basinSizes[2]);
        }
    }
}
