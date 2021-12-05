namespace AoC2021Class.Day04
{
    public class BingoElement
    {
        public BingoElement(int number)
        {
            Number = number;
        }
        public override string ToString() => $"{Number} - {IsDrawn}";
        public int Number { get; }
        public bool IsDrawn = false;
    }
}
