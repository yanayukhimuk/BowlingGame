namespace BowlingGameLib
{
    public class Game
    {
        private readonly int[] _rolls;
        private int _currentRoll;

        public Game()
        {
            _rolls = new int[21];

        }
        public int Score()
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(rollIndex))
                {
                    score += 10 + _rolls[rollIndex + 2];
                }
                else
                {
                    score += _rolls[rollIndex] + _rolls[rollIndex + 1];
                }
                rollIndex += 2;
            }        
            return score;
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private bool IsSpare(int i)
        {
            return _rolls[i] + _rolls[i + 1] == 10;
        }
    }
}