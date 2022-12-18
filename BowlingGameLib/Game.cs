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
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare(frameIndex))
                {
                    score = SpareBonus(score, frameIndex);
                    frameIndex += 2;
                }
                else if (IsStrike(frameIndex))
                {
                    score = StrikeBonus(score, frameIndex);
                    frameIndex++;
                }
                else
                {
                    score = WithoutBonus(score, frameIndex);
                    frameIndex += 2;
                }
            }        
            return score;
        }

        private int WithoutBonus(int score, int frameIndex)
        {
            score += _rolls[frameIndex] + _rolls[frameIndex + 1];
            return score;
        }

        private int StrikeBonus(int score, int frameIndex)
        {
            score += 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
            return score;
        }

        private int SpareBonus(int score, int frameIndex)
        {
            score += 10 + _rolls[frameIndex + 2];
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

        private bool IsStrike(int i)
        {
            return _rolls[i] == 10;
        }
    }
}