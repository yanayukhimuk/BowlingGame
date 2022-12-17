using BowlingGameLib;

namespace BowlingGame.Tests
{
    public class BowlingGameTests
    {
        private Game _game;
        private int _laps;
        private int _pins;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
            _laps = 20;
        }

        [Test]
        //This test tests the game with 20 roll but zero score
        public void TestFullFailureGame()
        {
            _pins = 0;

            RollMany(_laps, _pins);

            Assert.AreEqual(0, _game.Score);
        }

        [Test]  
        public void TestFullSuccessGame() 
        {
            _pins = 10;

            RollMany(_laps, _pins);

            Assert.AreEqual(200, _game.Score);

        }

        [Test]
        public void TestAllOnes()
        {
            _pins = 1;

            RollMany(_laps, _pins);

            Assert.AreEqual(20, _game.Score);
        }

        private void RollMany (int laps, int pins)
        {
            for (int i = 0; i < laps; i++)
            {
                _game.Roll(pins);  
            }
        }
    }
}