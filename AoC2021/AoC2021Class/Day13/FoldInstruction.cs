namespace AoC2021Class.Day13
{
    public class FoldInstruction
    {
        public FoldInstruction(string rawDay13Instruction)
        {
            // Instruction format
            // fold along {line direction, x or y}={line number}

            string rawFoldLine = rawDay13Instruction.Split(' ')[2];
            string[] splittedFoldLine = rawFoldLine.Split('=');

            LineDirection = splittedFoldLine[0][0];
            LineNumber = int.Parse(splittedFoldLine[1]);
        }

        public override string ToString()
        {
            return $"{LineDirection}:{LineNumber}";
        }

        public char LineDirection { get; }
        public int LineNumber { get; }
    }
}
