namespace AoC2021Days
{
    public class Day21 : IDay
    {
        private const int P1Input = 8;
        private const int P2Input = 6;

        public int PlayerOnePos;
        public int PlayerTwoPos;

        public void SolvePartOne()
        {
            ResetPosition();
            int playerOneScore = 0;
            int playerTwoScore = 0;
            int dice = 0;
            int rollTime = 0;
            while (true)
            {
                int stepsToMove = 0;
                for (int i = 1; i <= 3; i++)
                {
                    dice = dice >= 100 ? 1 : dice + 1;
                    stepsToMove += dice;
                }

                if (rollTime % 6 == 0)
                {
                    PlayerOnePos += stepsToMove;
                    PlayerOnePos = PlayerOnePos % 10 == 0 ? 10 : PlayerOnePos % 10;
                    playerOneScore += PlayerOnePos;
                }
                else
                {
                    PlayerTwoPos += stepsToMove;
                    PlayerTwoPos = PlayerTwoPos % 10 == 0 ? 10 : PlayerTwoPos % 10;
                    playerTwoScore += PlayerTwoPos;
                }

                rollTime += 3;

                if (playerOneScore >= 1000)
                {
                    Console.WriteLine($"Player One Won at roll number {rollTime}. " +
                        $"Loser scored {playerTwoScore}. Result {rollTime * playerTwoScore}");
                    break;
                }
                if (playerTwoScore >= 1000)
                {
                    Console.WriteLine($"Player Two Won at roll number {rollTime}. " +
                        $"Loser scored {playerOneScore}. Result {rollTime * playerOneScore}");
                    break;
                }
            }
        }

        public void SolvePartTwo()
        {
            throw new NotImplementedException();
        }

        private void ResetPosition()
        {
            PlayerOnePos = P1Input;
            PlayerTwoPos = P2Input;
        }
    }
}
