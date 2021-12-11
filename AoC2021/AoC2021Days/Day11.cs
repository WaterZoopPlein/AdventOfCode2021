using AoC2021Core;

namespace AoC2021Days
{
    public class Day11 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day11.txt", "\n");
        private static readonly int[,] OctopiGrid =
            ReadInput.ConvertInputStringListTo2DArray(InputList);

        public void SolvePartOne()
        {
            int flashNumbers = 0;
            for (int cycle = 0; cycle < 100; cycle++)
            {
                CycleOnce(out var numberOfFlashedOctopi);
                flashNumbers += numberOfFlashedOctopi;
            }
            Console.WriteLine(flashNumbers);
        }

        public void SolvePartTwo()
        {
            int flashNumbersInOneCycle = 0;
            int currentCycleNumber = 100; // Part One already cycled 100 times.
            while (flashNumbersInOneCycle != OctopiGrid.Length)
            {
                CycleOnce(out flashNumbersInOneCycle);
                currentCycleNumber += 1;
            }
            Console.WriteLine($"Found at cycle {currentCycleNumber}");
        }

        public void CycleOnce(out int numberOfFlashedOctopi)
        {
            Queue<(int LineNo, int RowNo)> flashQueueTracker = new();
            List<(int LineNo, int RowNo)> octopiToResetList = new();

            EnergiseTheOctopi(flashQueueTracker, octopiToResetList);

            FlashTheOctopi(flashQueueTracker, octopiToResetList);

            ResetTheOctopi(octopiToResetList);

            numberOfFlashedOctopi = octopiToResetList.Count;
        }

        private static void EnergiseTheOctopi(Queue<(int LineNo, int RowNo)> flashQueueTracker, List<(int LineNo, int RowNo)> octopiToResetList)
        {
            for (int lineNumber = 0; lineNumber < OctopiGrid.GetLength(0); lineNumber++)
            {
                for (int columeNumber = 0; columeNumber < OctopiGrid.GetLength(1); columeNumber++)
                {
                    OctopiGrid[lineNumber, columeNumber] += 1;
                    if (OctopiGrid[lineNumber, columeNumber] > 9)
                    {
                        flashQueueTracker.Enqueue((lineNumber, columeNumber));
                        octopiToResetList.Add((lineNumber, columeNumber));
                    }
                }
            }
        }

        private static void FlashTheOctopi(Queue<(int LineNo, int RowNo)> flashQueueTracker, List<(int LineNo, int RowNo)> octopiToResetList)
        {
            while (flashQueueTracker.TryDequeue(out var octopus))
            {
                var neighbours = new (int LineNo, int RowNo)[]
                {
                        (octopus.LineNo - 1, octopus.RowNo - 1),
                        (octopus.LineNo - 1, octopus.RowNo),
                        (octopus.LineNo - 1, octopus.RowNo + 1),
                        (octopus.LineNo, octopus.RowNo - 1),
                        (octopus.LineNo, octopus.RowNo + 1),
                        (octopus.LineNo + 1, octopus.RowNo - 1),
                        (octopus.LineNo + 1, octopus.RowNo),
                        (octopus.LineNo + 1, octopus.RowNo + 1),
                };

                foreach (var neighbour in neighbours)
                {
                    if (neighbour.LineNo >= 0 && neighbour.LineNo < OctopiGrid.GetLength(0)
                        && neighbour.RowNo >= 0 && neighbour.RowNo < OctopiGrid.GetLength(1))
                    {
                        OctopiGrid[neighbour.LineNo, neighbour.RowNo] += 1;
                        if (OctopiGrid[neighbour.LineNo, neighbour.RowNo] == 10)
                        {
                            flashQueueTracker.Enqueue((neighbour.LineNo, neighbour.RowNo));
                            octopiToResetList.Add((neighbour.LineNo, neighbour.RowNo));
                        }
                    }
                }
            }
        }

        private static void ResetTheOctopi(List<(int LineNo, int RowNo)> octopiToResetList)
        {
            foreach (var octopus in octopiToResetList)
            {
                OctopiGrid[octopus.LineNo, octopus.RowNo] = 0;
            }
        }

    }
}
