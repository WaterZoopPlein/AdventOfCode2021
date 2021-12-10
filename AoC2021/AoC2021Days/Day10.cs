using AoC2021Class.Day10;
using AoC2021Core;

namespace AoC2021Days
{
    public class Day10 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day10.txt", "\n");

        private static readonly List<DecodeResult> DecodedResultsList =
            InputList.ConvertAll(x => ChunksDecode.DecodeChunks(x));

        private static readonly Dictionary<char, int> ErrorPoints = new()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        private static readonly Dictionary<char, int> AutoCompletePoints = new()
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 },
        };

        public void SolvePartOne()
        {
            var errorScore = 0;
            foreach (var results in from DecodeResult results in DecodedResultsList
                                    where results.ChunkTypes == ChunkTypes.Corrupted
                                    select results)
            {
                errorScore += ErrorPoints[results.Info[0]];
            }

            Console.WriteLine(errorScore);
        }

        public void SolvePartTwo()
        {
            var incompleteResults = (from DecodeResult results in DecodedResultsList
                                     where results.ChunkTypes == ChunkTypes.Incomplete
                                     select results).ToArray();

            var autocompleteScores = new long[incompleteResults.Length];

            for (int i = 0; i < incompleteResults.Length; i++)
            {
                long currentAutoCompleteScore = 0;
                var currentResult = incompleteResults[i];

                foreach (char item in currentResult.Info)
                {
                    currentAutoCompleteScore *= 5;
                    currentAutoCompleteScore += AutoCompletePoints[item];
                }

                autocompleteScores[i] = currentAutoCompleteScore;
            }

            Array.Sort(autocompleteScores);
            Console.WriteLine(autocompleteScores[(autocompleteScores.Length - 1) / 2]);
        }
    }
}
