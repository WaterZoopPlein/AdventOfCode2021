using AoC2021Class.Day05;
using AoC2021Class.Day13;
using AoC2021Core;

namespace AoC2021Days
{
    public class Day13 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day13.txt", "\n\n");

        private static readonly List<string> RawCoordArray =
            InputList[0].Trim().Split('\n').ToList();
        private static readonly List<string> RawInstruction =
            InputList[1].Trim().Split('\n').ToList();

        private static readonly List<Point> ConvertedCoordList =
            RawCoordArray.ConvertAll(x => new Point(x));
        private static readonly List<FoldInstruction> ConvertedInstruction =
            RawInstruction.ConvertAll(x => new FoldInstruction(x));

        public void SolvePartOne()
        {
            var foldedCoords = ExecuteFoldInstruction(ConvertedCoordList, ConvertedInstruction[0]);
            Console.WriteLine(foldedCoords.Count);
        }

        public void SolvePartTwo()
        {
            var foldedCoords = ExecuteFoldInstruction(ConvertedCoordList, ConvertedInstruction[0]);
            for (int i = 1; i < ConvertedInstruction.Count; i++)
            {
                foldedCoords = ExecuteFoldInstruction(foldedCoords, ConvertedInstruction[i]);
            }

            var grid = new bool[6, 40];
            // no clue how to get the dimension, apart from eyeballing
            // the last vertical and horizontal folding instructions.

            for (int i = 0; i < foldedCoords.Count; i++)
            {
                grid[foldedCoords[i].Y, foldedCoords[i].X] = true;
            }

            PrintGrid(grid, '█');
        }

        private List<Point> ExecuteFoldInstruction(List<Point> convertedCoordList, FoldInstruction foldInstruction)
        {
            List<Point> foldedCoords = new();
            Point? pointToAdd = null;

            for (int coordIndex = 0; coordIndex < convertedCoordList.Count; coordIndex++)
            {
                if (foldInstruction.LineDirection == 'x')
                {
                    if (convertedCoordList[coordIndex].X > foldInstruction.LineNumber)
                    {
                        pointToAdd = new Point(2 * foldInstruction.LineNumber - convertedCoordList[coordIndex].X,
                            convertedCoordList[coordIndex].Y);
                    }
                    else if (convertedCoordList[coordIndex].X < foldInstruction.LineNumber)
                    {
                        pointToAdd = new Point(convertedCoordList[coordIndex].X,
                            convertedCoordList[coordIndex].Y);
                    }
                }
                else if (foldInstruction.LineDirection == 'y')
                {
                    if (convertedCoordList[coordIndex].Y > foldInstruction.LineNumber)
                    {
                        pointToAdd = new Point(convertedCoordList[coordIndex].X,
                            2 * foldInstruction.LineNumber - convertedCoordList[coordIndex].Y);
                    }
                    else if (convertedCoordList[coordIndex].Y < foldInstruction.LineNumber)
                    {
                        pointToAdd = new Point(convertedCoordList[coordIndex].X,
                            convertedCoordList[coordIndex].Y);
                    }
                }

                if (pointToAdd != null & !foldedCoords.Contains(pointToAdd))
                {
                    foldedCoords.Add(pointToAdd);
                }
            }
            return foldedCoords;


        }

        private static void PrintGrid(bool[,] grid, char trueValue = 'O', char falseValue = ' ')
        {
            for (int lineNum = 0; lineNum < grid.GetLength(0); lineNum++)
            {
                for (int rowNum = 0; rowNum < grid.GetLength(1); rowNum++)
                {
                    if (grid[lineNum, rowNum])
                    {
                        Console.Write(trueValue);
                    }
                    else
                    {
                        Console.Write(falseValue);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
