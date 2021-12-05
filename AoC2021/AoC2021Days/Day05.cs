using AoC2021Class.Day05;
using AoC2021Core;

namespace AoC2021Days
{
    public class Day05 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day05.txt", "\n");

        private static readonly List<Line> ConvertedInputList =
            InputList.ConvertAll(x => new Line(x));

        public void SolvePartOne()
        {
            var map = new Map();
            foreach (var line in ConvertedInputList)
            {
                if (line.IsVertical | line.IsHorizontal)
                {
                    map.DrawLines(line);
                }
            }

            int overlapCounts = map.CountOverlaps();

            Console.WriteLine(overlapCounts);
        }

        public void SolvePartTwo()
        {
            var map = new Map();
            foreach (var line in ConvertedInputList)
            {
                map.DrawLines(line);
            }

            int overlapCounts = map.CountOverlaps();

            Console.WriteLine(overlapCounts);
        }
    }
}
