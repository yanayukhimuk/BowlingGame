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
        }

        [Test]
        //This test tests the game with 20 roll but zero score
        public void TestFullFailureGame()
        {
            _laps = 20;
            _pins = 0;  

            RollMany(_laps, _pins);

            Assert.That(_game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void TestStrike()
        {
            _laps = 16;
            _pins = 0;
            
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);

            RollMany(_laps, _pins);

            Assert.That(_game.Score(), Is.EqualTo(24));
        }

        [Test]  
        public void TestFullSuccessGame() 
        {
            _laps = 12;
            
            for (int i = 0; i < _laps; i++) 
            {
                RollStrike();
            }

            Assert.That(_game.Score(), Is.EqualTo(300));

        }

        [Test]
        public void TestOneSpare() 
        {
            _laps = 17;
            _pins = 0; 

            RollSpare();
            _game.Roll(3);

            RollMany(_laps, _pins);

            Assert.That(_game.Score(), Is.EqualTo(16));
        }

        [Test]
        public void TestAllOnes()
        {
            _laps = 20;
            _pins = 1;

            RollMany(_laps, _pins);

            Assert.That(_game.Score(), Is.EqualTo(20));
        }

        private void RollMany (int laps, int pins)
        {
            for (int i = 0; i < laps; i++)
            {
                _game.Roll(pins);  
            }
        }

        private void RollSpare()
        {
            Random rnd = new Random();  
            int firstScore = rnd.Next(10);
            int secondScore = 10 - firstScore;

            _game.Roll(firstScore);
            _game.Roll(secondScore);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}