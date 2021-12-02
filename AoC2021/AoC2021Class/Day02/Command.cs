namespace AoC2021Class.Day02
{
    public class Command
    {
        public Command(string strCommand)
        {
            var commandArray = strCommand.Split(' ');

            Direction = Enum.TryParse<Direction>(commandArray[0], true, out var directionOutput) 
                ? directionOutput : Direction.Invalid;

            Step = int.TryParse(commandArray[1], out var stepOutput)
                ? stepOutput : -1;
        }

        public Direction Direction { get; set; }
        public int Step { get; set; }
        public override string ToString() => string.Format("{0} {1}", Direction, Step);
    }
}
