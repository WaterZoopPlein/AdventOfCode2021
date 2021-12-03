using AoC2021Core;
using AoC2021Class.Day02;

namespace AoC2021Days
{
    public class Day02 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day02.txt", '\n');

        private static readonly List<Command> ConvertedInputList =
            InputList.ConvertAll(x => new Command(x));


        public void SolvePartOne()
        {
            var currentPosition = new Position();

            foreach (var command in ConvertedInputList)
            {
                currentPosition.ExecuteCommandNoAim(command);
            }
            Console.WriteLine(currentPosition.Horizontal * currentPosition.Depth);
        }

        public void SolvePartTwo()
        {
            var currentPosition = new Position();

            foreach (var command in ConvertedInputList)
            {
                currentPosition.ExecuteCommandWithAim(command);
            }
            Console.WriteLine(currentPosition.Horizontal * currentPosition.Depth);
        }
    }
}
