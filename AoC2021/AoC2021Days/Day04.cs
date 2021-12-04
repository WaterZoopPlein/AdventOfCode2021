using AoC2021Class.Day04;
using AoC2021Core;

namespace AoC2021Days
{
    public class Day04 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day04.txt", "\n\n");

        private static readonly List<BingoBoard> BingoBoardsList =
            InputList.GetRange(1, InputList.Count - 1).ConvertAll(x => new BingoBoard(x));

        private static readonly int[] DrawnNumbers =
            ReadInput.ConvertStringToIntList(InputList[0], ',').ToArray();

        public void SolvePartOne()
        {
            bool foundBingoBoard = false;

            foreach (var number in DrawnNumbers)
            {
                for (int i = 0; i < BingoBoardsList.Count; i++)
                {
                    var board = BingoBoardsList[i];
                    board.DrawNumber(number);
                }

                foreach (var board in BingoBoardsList)
                {
                    if (board.IsWinner)
                    {
                        foundBingoBoard = true;
                        Console.WriteLine($"First Winning Board {board.BoardId}. Winning Number {number}. Score {board.CalculateScore()}");
                        break;
                    }
                }
                if (foundBingoBoard) break;
            }
        }

        public void SolvePartTwo()
        {
            foreach (var board in BingoBoardsList)
            {
                board.ResetBoard();
            }

            BingoBoard? lastWinningBoard = null;
            int lastWinningNumber = -1;
            foreach (var number in DrawnNumbers)
            {
                for (int i = 0; i < BingoBoardsList.Count; i++)
                {
                    var board = BingoBoardsList[i];
                    board.DrawNumber(number);
                }

                foreach (var board in BingoBoardsList)
                {
                    if (board.IsWinner & board.BingoNumber == number)
                    {
                        lastWinningBoard = board;
                        lastWinningNumber = number;
                        // Console.WriteLine($"BINGO! Board {board.BoardId}. Winning Number {number}. Score {board.CalculateScore()}");
                    }
                }
            }
            Console.WriteLine($"Last Winning Board {lastWinningBoard?.BoardId}. Last Winning Number {lastWinningNumber}. Score {lastWinningBoard?.CalculateScore()}");
        }
    }
}
