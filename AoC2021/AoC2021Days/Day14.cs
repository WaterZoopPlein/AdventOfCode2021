using AoC2021Core;

namespace AoC2021Days
{
    public class Day14 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day14.txt", "\n\n");

        private string Polymer = "";
        private string[] RawInsertionPairs = { };

        private Dictionary<string, char> InsertionDictionary = new();
        private Dictionary<char, List<string>> InstructionElementPairDictionary = new();

        private Dictionary<string, long> PolymerPairOccurence = new();
        private Dictionary<char, long> CharOccurences = new();

        public void SolvePartOne()
        {
            Reset();

            for (int i = 0; i < 10; i++)
            {
                PolymerisePartOne();
            }

            var sortedCharOccurences = CharOccurences.OrderBy(k => k.Value);
            var first = sortedCharOccurences.FirstOrDefault();
            var last = sortedCharOccurences.LastOrDefault();
            Console.WriteLine(first.Key + " => " + first.Value);
            Console.WriteLine(last.Key + " => " + last.Value);
            Console.WriteLine($"Diff = {last.Value - first.Value}");
        }

        public void SolvePartTwo()
        {
            Reset();

            for (int i = 0; i < 40; i++)
            {
                PolymerisePartTwo();
            }

            var sortedCharOccurences = CharOccurences.OrderBy(k => k.Value);
            var first = sortedCharOccurences.FirstOrDefault();
            var last = sortedCharOccurences.LastOrDefault();
            Console.WriteLine(first.Key + " => " + first.Value);
            Console.WriteLine(last.Key + " => " + last.Value);
            Console.WriteLine($"Diff = {last.Value - first.Value}");
        }

        private void Reset()
        {
            Polymer = InputList[0].Trim();
            RawInsertionPairs = InputList[1].Trim().Split('\n');

            InsertionDictionary = new();
            InstructionElementPairDictionary = new();

            PolymerPairOccurence = new();
            CharOccurences = new();

            InitialiseElementPairDict();

            InitialiseCharOccurences();


            InitialisePolymerPairDict();
        }

        private void InitialiseCharOccurences()
        {
            foreach (var item in Polymer)
            {
                if (!CharOccurences.TryAdd(item, 1))
                {
                    CharOccurences[item] += 1;
                }
            }
        }

        private void InitialiseElementPairDict()
        {
            foreach (var (pair, elementPair) in from pair in RawInsertionPairs
                                                let elementPair = pair.Substring(0, 2)
                                                select (pair, elementPair))
            {
                if (!InstructionElementPairDictionary.ContainsKey(elementPair[0]))
                {
                    InstructionElementPairDictionary[elementPair[0]] = new List<string>() { elementPair };
                }
                else
                {
                    InstructionElementPairDictionary[elementPair[0]].Add(elementPair);
                }

                InsertionDictionary.Add(elementPair, pair[pair.Length - 1]);
            }
        }
        
        private void InitialisePolymerPairDict()
        {
            for (int templateIndex = 0; templateIndex < Polymer.Length - 1; templateIndex++)
            {
                string currentPair = Polymer.Substring(templateIndex, 2);
                if (!PolymerPairOccurence.TryAdd(currentPair, 1))
                {
                    PolymerPairOccurence[currentPair]++;
                }
            }
        }

        private void PolymerisePartOne()
        {
            List<(char charTobeInserted, int position)> insertInstructions = new();
            for (int templateIndex = 0; templateIndex < Polymer.Length - 1; templateIndex++)
            {
                string currentPair = Polymer.Substring(templateIndex, 2);
                bool canBeInserted = InstructionElementPairDictionary.ContainsKey(Polymer[templateIndex])
                    && InstructionElementPairDictionary[Polymer[templateIndex]].Contains(currentPair);

                if (canBeInserted)
                {
                    insertInstructions.Add((InsertionDictionary[currentPair], templateIndex + 1));
                }
            }
            ExecuteInsertInstructionsPartOne(insertInstructions);
        }

        private void ExecuteInsertInstructionsPartOne(List<(char charTobeInserted, int position)> insertInstructions)
        {
            int offset = 0;
            foreach (var instruction in insertInstructions)
            {
                Polymer = Polymer.Substring(0, instruction.position + offset)
                    + instruction.charTobeInserted
                    + Polymer.Substring(instruction.position + offset);
                offset++;

                if (!CharOccurences.TryAdd(instruction.charTobeInserted, 1))
                {
                    CharOccurences[instruction.charTobeInserted] += 1;
                }
            }
        }
        
        private void PolymerisePartTwo()
        {
            Dictionary<string, char> filteredInsertInstructions = new();
            foreach (var keyValue in PolymerPairOccurence)
            {
                string currentPair = keyValue.Key;
                bool canBeInserted = InstructionElementPairDictionary.ContainsKey(currentPair[0])
                    && InstructionElementPairDictionary[currentPair[0]].Contains(currentPair);

                if (canBeInserted)
                {
                    filteredInsertInstructions.Add(currentPair, InsertionDictionary[currentPair]);
                }
            }

            ExecuteInsertInstructionsPartTwo(filteredInsertInstructions);
        }

        private void ExecuteInsertInstructionsPartTwo(Dictionary<string, char> filteredInsertInstructions)
        {
            Dictionary<string, long> buffer = new();
            foreach (var instruction in filteredInsertInstructions)
            {
                var oldPair = instruction.Key;

                var newPairs = new string[]
                { $"{instruction.Key[0]}{instruction.Value}", $"{instruction.Value}{instruction.Key[1]}" };
                var occurrenceToReplace = buffer.ContainsKey(oldPair) ? buffer[oldPair] : PolymerPairOccurence[oldPair];
                if (!CharOccurences.TryAdd(instruction.Value, occurrenceToReplace))
                {
                    CharOccurences[instruction.Value] += occurrenceToReplace;
                }

                if (buffer.ContainsKey(oldPair))
                {
                    // substract main by buffer
                    PolymerPairOccurence[oldPair] -= buffer[oldPair];
                    // remove from buffer
                    buffer.Remove(oldPair);
                }
                else
                {
                    // remove old pair from main
                    PolymerPairOccurence.Remove(oldPair);
                }
                foreach (var newPair in newPairs)
                {
                    if (PolymerPairOccurence.ContainsKey(newPair))
                    {
                        // try add new pair to buffer
                        buffer.TryAdd(newPair, PolymerPairOccurence[newPair]);
                        // add new pair to main 
                        PolymerPairOccurence[newPair] += occurrenceToReplace;
                    }
                    else if (!PolymerPairOccurence.ContainsKey(newPair))
                    {
                        // add new pair to main 
                        PolymerPairOccurence.Add(newPair, occurrenceToReplace);
                    }
                }
            }
        }
    }
}
