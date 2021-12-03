using AoC2021Core;

namespace AoC2021Days
{
    public class Day03 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day03.txt", '\n');
        private readonly int binaryLength = InputList[0].Length;

        public void SolvePartOne()
        {
            GetGammaAndEpsilon(out string binaryGamma, out string binaryEpsilon);

            int gamma = Convert.ToInt32(binaryGamma, 2);
            int epsilon = Convert.ToInt32(binaryEpsilon, 2);

            Console.WriteLine($"Power Consumption is {gamma * epsilon}");
        }

        public void SolvePartTwo()
        {
            var oxygenBinary = GetOxygenGenRate(InputList)[0];
            var co2Binary = GetCO2ScrubRate(InputList)[0];

            int oxygen = Convert.ToInt32(oxygenBinary, 2);
            int co2Scrub = Convert.ToInt32(co2Binary, 2);

            Console.WriteLine($"Life Support Rating is {oxygen * co2Scrub}");
        }

        private void GetGammaAndEpsilon(out string binaryGamma, out string binaryEpsilon)
        {
            int[] bitOneOccurence = new int[binaryLength];

            foreach (var item in InputList)
            {
                for (int i = 0; i < binaryLength; i++)
                {
                    if (item[i] == '1') bitOneOccurence[i]++;
                }
            }

            binaryGamma = "";
            binaryEpsilon = "";
            foreach (var item in bitOneOccurence)
            {
                if (item * 2 > InputList.Count)
                {
                    binaryGamma += "1";
                    binaryEpsilon += "0";
                }
                else
                {
                    binaryGamma += "0";
                    binaryEpsilon += "1";
                }
            }
        }

        private List<string> GetOxygenGenRate(List<string> inputBinaries, int pointerIndex = 0)
        {
            if (inputBinaries.Count <= 1)
                return inputBinaries;

            int bitOneOccurence = GetBitOneOccurence(inputBinaries, pointerIndex);

            var filtered = bitOneOccurence * 2 >= inputBinaries.Count
                ? inputBinaries.FindAll(x => x[pointerIndex] == '1')
                : inputBinaries.FindAll(x => x[pointerIndex] == '0');

            return GetOxygenGenRate(filtered, pointerIndex + 1);
        }

        private List<string> GetCO2ScrubRate(List<string> inputBinaries, int pointerIndex = 0)
        {
            if (inputBinaries.Count <= 1)
                return inputBinaries;

            int bitOneOccurence = GetBitOneOccurence(inputBinaries, pointerIndex);

            var filtered = bitOneOccurence * 2 >= inputBinaries.Count
                ? inputBinaries.FindAll(x => x[pointerIndex] == '0')
                : inputBinaries.FindAll(x => x[pointerIndex] == '1');

            return GetCO2ScrubRate(filtered, pointerIndex + 1);
        }

        private static int GetBitOneOccurence(List<string> inputBinaries, int pointerIndex)
        {
            return (from item in inputBinaries
                    where item[pointerIndex] == '1'
                    select item).Count();
        }
    }
}
