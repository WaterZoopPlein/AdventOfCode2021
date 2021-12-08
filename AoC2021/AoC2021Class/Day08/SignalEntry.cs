namespace AoC2021Class.Day08
{
    public class SignalEntry
    {
        private int[] segmentDisplayMap = {0b1110111, 0b0010010, 0b1011101, 0b1011011,
            0b0111010, 0b1101011, 0b1101111, 0b1010010, 0b1111111, 0b1111011};
        public SignalEntry(string strEntryLine)
        {
            var splittedEntry = strEntryLine.Split('|');
            InputArray = splittedEntry[0].Trim().Split(' ');
            OutputArray = splittedEntry[1].Trim().Split(' ');
            WireMap = new()
            {
                { 'a', -1 },
                { 'b', -1 },
                { 'c', -1 },
                { 'd', -1 },
                { 'e', -1 },
                { 'f', -1 },
                { 'g', -1 },
            };
            NumberMap = new();
        }

        public void Untangle()
        {
            AssignNumberFromUniqueSegmentCounts();

            var inputCharCount = new Dictionary<char, int>
            {
                { 'a', 0 },
                { 'b', 0 },
                { 'c', 0 },
                { 'd', 0 },
                { 'e', 0 },
                { 'f', 0 },
                { 'g', 0 },
            };
            foreach (var item in InputArray)
            {
                foreach (var character in item)
                {
                    inputCharCount[character] += 1;
                }
            }

            foreach (var keyValuePair in inputCharCount)
            {
                switch (keyValuePair.Value)
                {
                    case 4:
                        WireMap[keyValuePair.Key] = 0b0000100;
                        break;
                    case 6:
                        WireMap[keyValuePair.Key] = 0b0100000;
                        break;
                    case 9:
                        WireMap[keyValuePair.Key] = 0b0000010;
                        break;
                    case 8:
                        WireMap[keyValuePair.Key] =
                            NumberMap[4].Contains(keyValuePair.Key)
                            ? 0b0010000 : 0b1000000;
                        break;
                    case 7:
                        WireMap[keyValuePair.Key] =
                            NumberMap[4].Contains(keyValuePair.Key)
                            ? 0b0001000 : 0b0000001;
                        break;
                }
            }
        }

        public int DecodeOutput()
        {
            int output = 0;
            if (WireMap.ContainsValue(-1))
            {
                Console.WriteLine("Wiremap contains -1. " +
                    "Pls call Untangle() function first, or double check the Untangle function");
                return -1;
            }
            else
            {
                for (int i = 0; i < OutputArray.Length; i++)
                {
                    int segmentDisplay = 0;
                    foreach (var signal in OutputArray[i])
                    {
                        segmentDisplay += WireMap[signal];
                    }
                    output += Array.IndexOf(segmentDisplayMap, segmentDisplay)
                        * (int)Math.Pow(10, OutputArray.Length - 1 - i);
                }
            }
            return output;
        }

        private void AssignNumberFromUniqueSegmentCounts()
        {
            foreach (var input in InputArray)
            {
                switch (input.Length)
                {
                    case 2:
                        NumberMap.Add(1, input);
                        break;
                    case 3:
                        NumberMap.Add(7, input);
                        break;
                    case 4:
                        NumberMap.Add(4, input);
                        break;
                    case 7:
                        NumberMap.Add(8, input);
                        break;
                }
            }
        }

        public string[] InputArray { get; }
        public string[] OutputArray { get; }
        public Dictionary<int, string> NumberMap { get; set; }
        public Dictionary<char, int> WireMap { get; set; }
    }
}
