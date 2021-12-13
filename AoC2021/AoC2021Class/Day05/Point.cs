namespace AoC2021Class.Day05
{
    public class Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string coordPair, char delimiter = ',')
        {
            string[] convertedCoordPair = coordPair.Split(delimiter);
            X = int.Parse(convertedCoordPair[0]);
            Y = int.Parse(convertedCoordPair[1]);
        }

        public override string ToString() => $"{X},{Y}";

        public bool Equals(Point? other) => other != null & (X == other?.X && Y == other?.Y);

        public int X { get; }

        public int Y { get; }

    }
}
