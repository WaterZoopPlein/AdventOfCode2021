using AoC2021Core;

namespace AoC2021Days
{
    public class Day07 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day07.txt", "\n");
        private static readonly List<int> ConvertedInputList = //new() { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
            ReadInput.ConvertStringToIntIEnum(InputList[0], ',').ToList();

        public void SolvePartOne()
        {
            ConvertedInputList.Sort();
            int midIndex = ConvertedInputList.Count / 2;
            double median = ConvertedInputList.Count % 2 == 0
                ? (double)(ConvertedInputList[midIndex] + ConvertedInputList[midIndex - 1]) / 2
                : ConvertedInputList[midIndex];

            /// The median minimizes the sum of absolute deviations
            /// https://math.stackexchange.com/questions/113270/the-median-minimizes-the-sum-of-absolute-deviations-the-ell-1-norm

            // Verifying. Pick whichever is the lowest.
            Console.WriteLine($"Part 1 - {median}");
            Console.WriteLine(CalculateFuelPart1(Math.Round(median) - 2));
            Console.WriteLine(CalculateFuelPart1(Math.Round(median) - 1));
            Console.WriteLine(CalculateFuelPart1(Math.Round(median)));
            Console.WriteLine(CalculateFuelPart1(Math.Round(median) + 1));
            Console.WriteLine(CalculateFuelPart1(Math.Round(median) + 2));
        }

        public void SolvePartTwo()
        {
            // Just minimise the square error
            // The mean could achieve it
            double mean = (double)ConvertedInputList.Sum() / ConvertedInputList.Count;

            // Verifying. Pick whichever is the lowest.
            Console.WriteLine($"Part 2. Mean = {mean}");
            Console.WriteLine(CalculateFuelPart2(Math.Round(mean) - 2));
            Console.WriteLine(CalculateFuelPart2(Math.Round(mean) - 1));
            Console.WriteLine(CalculateFuelPart2(Math.Round(mean)));
            Console.WriteLine(CalculateFuelPart2(Math.Round(mean) + 1));
            Console.WriteLine(CalculateFuelPart2(Math.Round(mean) + 2));

        }

        private static double CalculateFuelPart1(double median)
        {
            double fuel = 0;

            foreach (var input in ConvertedInputList)
            {
                fuel += Math.Abs(input - median);
            }

            return fuel;
        }

        private static double CalculateFuelPart2(double destination)
        {
            double fuel = 0;
            foreach (var input in ConvertedInputList)
            {
                fuel += 0.5 * (Math.Pow(input - destination, 2) + Math.Abs(input - destination));
            }

            return fuel;
        }
    }
}
