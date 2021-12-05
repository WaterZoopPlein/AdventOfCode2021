namespace AoC2021Class.Day05
{
    public class Map
    {
        internal Dictionary<string, int> map;

        public Map()
        {
            map = new();
        }

        public void DrawLines(Line inputLine)
        {
            if (inputLine.IsVertical)
            {
                DrawVerticalLine(inputLine);
            }
            else if (inputLine.IsHorizontal)
            {
                DrawHorizontalLine(inputLine);
            }
            else
            {
                Draw45DegreeLine(inputLine);
            }
        }

        public int CountOverlaps() => (from keyValuePair in map
                                       where keyValuePair.Value >= 2
                                       select keyValuePair).Count();

        private void DrawVerticalLine(Line inputLine)
        {
            int pointsNumber = Math.Abs(inputLine.Point1.Y - inputLine.Point2.Y) + 1;

            Point[] pointsToDraw = new Point[pointsNumber];
            int startDrawPointX = inputLine.Point1.X;
            int startDrawPointY =
                inputLine.Point1.Y <= inputLine.Point2.Y
                ? inputLine.Point1.Y
                : inputLine.Point2.Y;

            for (int i = 0; i < pointsToDraw.Length; i++)
            {
                pointsToDraw[i] = new Point(startDrawPointX, startDrawPointY + i);
            }

            MarkPoints(pointsToDraw);
        }

        private void DrawHorizontalLine(Line inputLine)
        {
            int pointsNumber = Math.Abs(inputLine.Point1.X - inputLine.Point2.X) + 1;

            Point[] pointsToDraw = new Point[pointsNumber];
            int startDrawPointX = inputLine.Point1.X <= inputLine.Point2.X
                ? inputLine.Point1.X
                : inputLine.Point2.X;
            int startDrawPointY = inputLine.Point1.Y;

            for (int i = 0; i < pointsToDraw.Length; i++)
            {
                pointsToDraw[i] = new Point(startDrawPointX + i, startDrawPointY);
            }

            MarkPoints(pointsToDraw);
        }

        private void Draw45DegreeLine(Line inputLine)
        {
            int pointsNumber = Math.Abs(inputLine.Point1.X - inputLine.Point2.X) + 1;

            Point[] pointsToDraw = new Point[pointsNumber];
            var startDrawPoint = inputLine.Point1.X <= inputLine.Point2.X
                ? inputLine.Point1
                : inputLine.Point2;
            var endDrawPoint = inputLine.Point1.X <= inputLine.Point2.X
                ? inputLine.Point2
                : inputLine.Point1;
            var gradient = startDrawPoint.Y < endDrawPoint.Y ? 1 : -1;

            for (int i = 0; i < pointsToDraw.Length; i++)
            {
                pointsToDraw[i] = new Point(startDrawPoint.X + i, startDrawPoint.Y + i * gradient);
            }

            MarkPoints(pointsToDraw);
        }

        private void MarkPoints(Point[] pointsToDraw)
        {
            foreach (Point point in pointsToDraw)
            {
                string strPointToDraw = point.ToString();
                if (map.ContainsKey(strPointToDraw))
                {
                    map[strPointToDraw] += 1;
                }
                else
                {
                    map.Add(strPointToDraw, 1);
                }
            }
        }
    }
}
