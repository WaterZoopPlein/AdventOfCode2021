namespace AoC2021Class.Day04
{
    public class BingoBoard
    {
        private readonly int boardSize;
        private static int boardIdStatic = 0;
        public BingoBoard(string strBoard)
        {
            var strLinesArr = strBoard.Trim().Split('\n');
            boardSize = strLinesArr.Length;

            BoardId = boardIdStatic;
            boardIdStatic++;

            Board = new BingoElement[boardSize, boardSize];
            RowDrawnNumberCount = new int[boardSize];
            ColumeDrawnNumberCount = new int[boardSize];
            IsWinner = false;
            Message = "Board initalised";
            BingoNumber = -1;

            for (int lineNumber = 0; lineNumber < boardSize; lineNumber++)
            {
                var splittedLine = strLinesArr[lineNumber].Split(' ');
                var columnNumberOffset = 0;
                for (int columeNumber = 0; columeNumber < splittedLine.Length; columeNumber++)
                {
                    if (splittedLine[columeNumber] == "")
                    {
                        columnNumberOffset++;
                        continue;
                    }
                    Board[lineNumber, columeNumber - columnNumberOffset] = new BingoElement(int.Parse(splittedLine[columeNumber]));
                }
            }
        }

        public void DrawNumber(int number)
        {
            if (IsWinner) return;

            bool found = false;
            int foundRowNumber = -1;
            int foundColumeNumber = -1;

            for (var rowNumber = 0; rowNumber < Board.GetLength(0); rowNumber++)
            {
                for (var columeNumber = 0; columeNumber < Board.GetLength(1); columeNumber++)
                {
                    if (Board[rowNumber, columeNumber].Number == number)
                    {
                        found = true;
                        Board[rowNumber, columeNumber].IsDrawn = true;

                        foundRowNumber = rowNumber;
                        foundColumeNumber = columeNumber;
                        RowDrawnNumberCount[rowNumber]++;
                        ColumeDrawnNumberCount[columeNumber]++;

                        CheckBingoOnRowAndColume(rowNumber, columeNumber);
                        if (IsWinner) BingoNumber = number;
                        break;
                    }
                }

                if (found) break;
            }

            UpdateMessage(found, foundRowNumber, foundColumeNumber);
        }

        public int CalculateScore()
        {
            int uncalledSum = 0;
            foreach (var item in Board)
            {
                if (!item.IsDrawn) uncalledSum += item.Number;
            }

            return uncalledSum * BingoNumber;

        }

        public void ResetBoard()
        {
            foreach (var item in Board)
                item.IsDrawn = false;

            IsWinner = false;
            Message = "Board reset.";
            BingoNumber = -1;

            for (int i = 0; i < RowDrawnNumberCount.Length; i++)
                RowDrawnNumberCount[i] = 0;

            for (int j = 0; j < ColumeDrawnNumberCount.Length; j++)
                ColumeDrawnNumberCount[j] = 0;
        }

        private void UpdateMessage(bool found, int foundRowNumber = -1, int foundColumeNumber = -1)
        {
            if (!found)
            {
                Message = $"Number {BingoNumber} not found.";
            }
            else
            {
                Message = $"Found {BingoNumber} at row {foundRowNumber}, colume {foundColumeNumber}.";
                if (IsWinner)
                {
                    Message += " BINGO!";
                }
            }
        }

        private void CheckBingoOnRowAndColume(int rowNumber, int columeNumber)
        {
            if (RowDrawnNumberCount[rowNumber] == Board.GetLength(0)
                | ColumeDrawnNumberCount[columeNumber] == Board.GetLength(1))
            {
                IsWinner = true;
            }
        }

        public override string ToString() => Message;

        public int BoardId { get; }
        public BingoElement[,] Board { get; }
        public int[] RowDrawnNumberCount { get; }
        public int[] ColumeDrawnNumberCount { get; }
        public int BingoNumber { get; set; }
        public bool IsWinner { get; set; }
        public string Message { get; set; }
    }
}
