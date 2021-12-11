namespace AoC2021Class.Day09
{
    public class MapUtility
    {
        public static bool LowPointCheck(int[,] map, int lineNumber, int rowNumber)
        {
            int currentHeight = map[lineNumber, rowNumber];
            if (currentHeight == 9)
            {
                return false;
            }

            int north = lineNumber <= 0 ? -1 : map[lineNumber - 1, rowNumber];
            int south = lineNumber >= map.GetLength(0) - 1 ? -1 : map[lineNumber + 1, rowNumber];
            int west = rowNumber <= 0 ? -1 : map[lineNumber, rowNumber - 1];
            int east = rowNumber >= map.GetLength(1) - 1 ? -1 : map[lineNumber, rowNumber + 1];

            bool isLowPoint = (north == -1 | currentHeight < north)
                & (south == -1 | currentHeight < south)
                & (west == -1 | currentHeight < west)
                & (east == -1 | currentHeight < east);
            return isLowPoint;
        }

        public static int BasinSize(int[,] map, int lineNumber, int rowNumber)
        {
            if (!LowPointCheck(map, lineNumber, rowNumber))
            {
                return -1;
            }
            List<string> visitedPoint = new();
            Queue<Tuple<int, int>> pointQueue = new();

            int size = 1;
            visitedPoint.Add($"{lineNumber},{rowNumber}");
            pointQueue.Enqueue(new Tuple<int, int>(lineNumber, rowNumber));

            while (pointQueue.Count > 0)
            {
                var currentPoint = pointQueue.Dequeue();
                var currentLine = currentPoint.Item1;
                var currentRow = currentPoint.Item2;

                // North
                if (currentLine > 0 
                    & !visitedPoint.Contains($"{currentLine - 1},{currentRow}"))
                {
                    int northHeight = map[currentLine - 1, currentRow];
                    if (northHeight < 9)
                    {
                        pointQueue.Enqueue(new Tuple<int, int>(currentLine - 1, currentRow));
                        visitedPoint.Add($"{currentLine - 1},{currentRow}");
                        size += 1;
                    }
                }

                // South
                if (currentLine < map.GetLength(0) - 1
                    & !visitedPoint.Contains($"{currentLine + 1},{currentRow}"))
                {
                    int southHeight = map[currentLine + 1, currentRow];
                    if (southHeight < 9)
                    {
                        pointQueue.Enqueue(new Tuple<int, int>(currentLine + 1, currentRow));
                        visitedPoint.Add($"{currentLine + 1},{currentRow}");
                        size += 1;
                    }
                }

                // West
                if (currentRow > 0
                    & !visitedPoint.Contains($"{currentLine},{currentRow - 1}"))
                {
                    int westHeight = map[currentLine, currentRow - 1];
                    if (westHeight < 9)
                    {
                        pointQueue.Enqueue(new Tuple<int, int>(currentLine, currentRow - 1));
                        visitedPoint.Add($"{currentLine},{currentRow - 1}");
                        size += 1;
                    }
                }

                // East
                if (currentRow < map.GetLength(1) - 1
                    & !visitedPoint.Contains($"{currentLine},{currentRow + 1}"))
                {
                    int eastHeight = map[currentLine, currentRow + 1];
                    if (eastHeight < 9)
                    {
                        pointQueue.Enqueue(new Tuple<int, int>(currentLine, currentRow + 1));
                        visitedPoint.Add($"{currentLine},{currentRow + 1}");
                        size += 1;
                    }
                }
            }

            return size;
        }
    }
}
