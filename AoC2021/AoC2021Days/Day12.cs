using AoC2021Core;

namespace AoC2021Days
{
    public class Day12 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day12.txt", "\n");
        private Dictionary<string, List<string>> AdjacencyDictionary = new();

        public void SolvePartOne()
        {
            InitialiseAdjacencyList();

            var i = CountPathsSmallCaveOnce("start");
            Console.WriteLine($"{i} paths in total.");
        }

        public void SolvePartTwo()
        {
            var i = CountPathsSmallCaveTwiceOnce("start");
            Console.WriteLine($"{i} paths in total.");
        }

        private int CountPathsSmallCaveOnce(string startNode)
        {
            return CountPathsSmallCaveOnce(startNode, new string[] { "start" });
        }

        private int CountPathsSmallCaveOnce(string startNode, string[] visitedNodes)
        {
            if (startNode == "end")
            {
                return 1;
            }

            var neighbourNodes = AdjacencyDictionary[startNode];

            var visitedNodeForNextStack = new string[visitedNodes.Count() + 1];
            for (int i = 0; i < visitedNodes.Length; i++)
            {
                visitedNodeForNextStack[i] = visitedNodes[i];
            }

            int pathsCount = 0;
            foreach (var neighbourNode in neighbourNodes)
            {
                bool isNotStart = neighbourNode != "start";
                bool isUpperCase = neighbourNode.Any(c => char.IsUpper(c));
                bool isLowerCase = neighbourNode.Any(c => char.IsLower(c));

                bool isPassable = isNotStart
                    && (isUpperCase || (!visitedNodes.Contains(neighbourNode)));
                if (isPassable)
                {
                    visitedNodeForNextStack[visitedNodes.Length] = neighbourNode;
                    pathsCount += CountPathsSmallCaveOnce(neighbourNode, visitedNodeForNextStack);
                }
            }
            return pathsCount;
        }

        private int CountPathsSmallCaveTwiceOnce(string startNode)
        {
            var lowerCaseOccurenceLog = new Dictionary<string, int>() { };
            return CountPathsSmallCaveTwice(startNode, lowerCaseOccurenceLog);
        }

        private int CountPathsSmallCaveTwice(string startNode, Dictionary<string, int> lowerCaseOccurenceLog)
        {
            if (startNode == "end")
            {
                return 1;
            }

            var neighbourNodes = AdjacencyDictionary[startNode];

            int pathsCount = 0;
            foreach (var neighbourNode in neighbourNodes)
            {
                bool isNotStart = neighbourNode != "start";
                bool isUpperCase = neighbourNode.Any(c => char.IsUpper(c));
                bool isLowerCase = neighbourNode.Any(c => char.IsLower(c));

                bool isPassable = isNotStart
                    && (isUpperCase
                    || !lowerCaseOccurenceLog.ContainsKey(neighbourNode)
                    || !lowerCaseOccurenceLog.ContainsValue(2));
                if (isPassable)
                {
                    var lowerCaseOccurenceLogForNextStack = new Dictionary<string, int>(lowerCaseOccurenceLog);

                    if (isLowerCase)
                    {
                        if (lowerCaseOccurenceLog.ContainsKey(neighbourNode))
                        {
                            lowerCaseOccurenceLogForNextStack[neighbourNode] += 1;
                        }
                        else
                        {
                            lowerCaseOccurenceLogForNextStack.Add(neighbourNode, 1);
                        }
                    }
                    pathsCount += CountPathsSmallCaveTwice(neighbourNode, lowerCaseOccurenceLogForNextStack);
                }
            }
            return pathsCount;

        }

        private void InitialiseAdjacencyList()
        {
            foreach (var pair in from item in InputList
                                 let pair = item.Split('-')
                                 select pair)
            {
                if (!AdjacencyDictionary.ContainsKey(pair[0]))
                {
                    AdjacencyDictionary[pair[0]] = new List<string> { pair[1] };
                }
                else
                {
                    AdjacencyDictionary[pair[0]].Add(pair[1]);
                }

                if (!AdjacencyDictionary.ContainsKey(pair[1]))
                {
                    AdjacencyDictionary[pair[1]] = new List<string> { pair[0] };
                }
                else
                {
                    AdjacencyDictionary[pair[1]].Add(pair[0]);
                }
            }
        }
    }
}
