namespace AoC2021Class.Day05
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{X},{Y}";

        public int X { get; }
        public int Y { get; }

    }
}
