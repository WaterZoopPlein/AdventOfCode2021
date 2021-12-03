namespace AoC2021Class.Day02
{
    public class Position
    {
        public Position()
        {
            Horizontal = 0;
            Depth = 0;
            Aim = 0;
        }

        public override string ToString() => string.Format("Hor-{0} Dep-{1} Aim-{2}",
            Horizontal, Depth, Aim);

        public void ExecuteCommandNoAim(Command command)
        {
            if (command.Step == -1) return;

            switch (command.Direction)
            {
                case Direction.Forward:
                    Horizontal += command.Step;
                    break;
                case Direction.Up:
                    Depth -= command.Step;
                    break;
                case Direction.Down:
                    Depth += command.Step;
                    break;
                case Direction.Invalid:
                    break;
                default:
                    break;
            }
        }

        public void ExecuteCommandWithAim(Command command)
        {
            if (command.Step == -1) return;

            switch (command.Direction)
            {
                case Direction.Forward:
                    Horizontal += command.Step;
                    Depth += Aim * command.Step;
                    break;
                case Direction.Up:
                    Aim -= command.Step;
                    break;
                case Direction.Down:
                    Aim += command.Step;
                    break;
                case Direction.Invalid:
                    break;
                default:
                    break;
            }
        }
        public int Horizontal { get; set; }
        public int Depth { get; set; }
        public int Aim { get; set; }
    }
}
