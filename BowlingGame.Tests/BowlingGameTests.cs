using BowlingGameLib;

namespace BowlingGame.Tests
{
    public class BowlingGameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //This test tests the game with 20 roll but zero score
        public void TestFullGFailureGame()
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++) 
            {
                game.Roll(0);
            }

            Assert.AreEqual(0, game.Score);
        }
    }
}