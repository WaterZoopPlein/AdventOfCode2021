namespace AoC2021Class.Day05
{
    public class Line
    {
        public Line(string rawInput)
        {
            RawInput = rawInput;

            var splittedInput = rawInput.Split(' ');
            var rawStartingPoint = splittedInput[0].Split(',');
            var rawEndingPoint = splittedInput[2].Split(',');

            Point1 = new Point(int.Parse(rawStartingPoint[0]), int.Parse(rawStartingPoint[1]));
            Point2 = new Point(int.Parse(rawEndingPoint[0]), int.Parse(rawEndingPoint[1]));
        }

        public override string ToString() => RawInput;

        public string RawInput { get; }
        public Point Point1 { get; }
        public Point Point2 { get; }
        public bool IsHorizontal => Point1.Y == Point2.Y;
        public bool IsVertical => Point1.X == Point2.X;
    }
}
