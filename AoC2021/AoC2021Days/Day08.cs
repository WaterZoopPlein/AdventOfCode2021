using AoC2021Core;
using AoC2021Class.Day08;

namespace AoC2021Days
{
    public class Day08 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day08.txt", "\n");
        private static readonly List<SignalEntry> ConvertedInputList =
            InputList.ConvertAll(x => new SignalEntry(x));

        public void SolvePartOne()
        {
            var count = 0;
            foreach (SignalEntry? entry in ConvertedInputList)
            {
                var outputs = entry.OutputArray;
                foreach (var output in outputs)
                {
                    if (output.Length == 2 || output.Length == 4
                        || output.Length == 3 || output.Length == 7)
                    {
                        count += 1;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public void SolvePartTwo()
        {
            var outputSum = 0;
            foreach (var signalEntry in ConvertedInputList)
            {
                signalEntry.Untangle();
                outputSum += signalEntry.DecodeOutput();
            }
            Console.WriteLine(outputSum);
        }
    }
}
