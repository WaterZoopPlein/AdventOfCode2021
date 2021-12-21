using AoC2021Core;

namespace AoC2021Days
{
    public class Day17 : IDay
    {
        //private const int TargetXUpperBound = 30;
        //private const int TargetXLowerBound = 20;
        //private const int TargetYUpperBound = -5;
        //private const int TargetYLowerBound = -10;
        private const int TargetXUpperBound = 286;
        private const int TargetXLowerBound = 257;
        private const int TargetYUpperBound = -57;
        private const int TargetYLowerBound = -101;

        public void SolvePartOne()
        {
            // Ignore X. It's independent from Y.
            // Y symmetrical, it always touch zero-y-level.
            // Thus to reach the highest y,
            // initial y velocity = Y_lowerbound_magnitude - 1
            Console.WriteLine(TargetYLowerBound * -1 - 1);
        }

        public void SolvePartTwo()
        {
            // X Level
            Console.WriteLine("X");
            List<int> initialVelocityXList = new List<int>();
            Dictionary<int, List<int>> stepAndInitialVelocityXDict = new();
            for (int targetX = TargetXLowerBound; targetX < TargetXUpperBound + 1; targetX++)
            {
                int stepNo = 1;
                while (true)
                {
                    double initialVelocityX = (double) (2 * targetX + stepNo * (stepNo - 1)) / (2 * stepNo);

                    if (initialVelocityX >= stepNo)
                    {
                        bool isInt = initialVelocityX == (int)initialVelocityX;
                        if (isInt)
                        {
                            initialVelocityXList.Add((int)initialVelocityX);
                            if (!stepAndInitialVelocityXDict.ContainsKey(stepNo))
                            {
                                stepAndInitialVelocityXDict.Add(stepNo, new List<int>());
                            }
                            stepAndInitialVelocityXDict[stepNo].Add((int)initialVelocityX);
                        }
                    }
                    else
                    {
                        break;
                    }

                    stepNo++;
                }
            }

            // Y Level
            Console.WriteLine("Y");
            Dictionary<int, List<int>> stepAndInitialVelocityYDict = new();
            for (int initialVy = TargetYLowerBound; initialVy <= TargetYLowerBound * -1 -1; initialVy++)
            {
                int yStepNumber = 0;
                int currentYLevel = 0;
                int Vy;

                if (initialVy >= 0)
                {
                    yStepNumber += initialVy * 2 + 1;
                    Vy = -initialVy - 1;
                }
                else
                {
                    Vy = initialVy;
                }

                while (true)
                {
                    if (currentYLevel <= TargetYUpperBound
                        && currentYLevel >= TargetYLowerBound)
                    {
                        if (!stepAndInitialVelocityYDict.ContainsKey(yStepNumber))
                        {
                            stepAndInitialVelocityYDict.Add(yStepNumber, new List<int>());
                        }
                        stepAndInitialVelocityYDict[yStepNumber].Add(initialVy);
                    }
                    else if (currentYLevel < TargetYLowerBound)
                    {
                        break;
                    }

                    currentYLevel += Vy;
                    Vy -= 1;
                    yStepNumber += 1;
                }
            }

            // Count
            List<string> initialVelocityPairs = new();
            foreach (var stepVxPair in stepAndInitialVelocityXDict)
            {
                var vyList = stepAndInitialVelocityYDict[stepVxPair.Key];
                foreach (var vx in stepVxPair.Value)
                {
                    if (vx == stepVxPair.Key)
                    {
                        var filteredStepAndInitialVelocityYDict = from pair in stepAndInitialVelocityYDict
                                                                  where pair.Key >= vx
                                                                  select pair;
                        foreach (var item in filteredStepAndInitialVelocityYDict)
                        {
                            foreach (var vy in item.Value)
                            {
                                if (!initialVelocityPairs.Contains($"{vx},{vy}"))
                                {
                                    initialVelocityPairs.Add($"{vx},{vy}");
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var vy in vyList)
                        {
                            if (!initialVelocityPairs.Contains($"{vx},{vy}"))
                            {
                                initialVelocityPairs.Add($"{vx},{vy}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine(initialVelocityPairs.Count);
        }
    }
}
