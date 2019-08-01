using System;
using Xunit;
using Xunit.Abstractions;

namespace Minesweeper
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Return_CanStartGame()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var canStartGame = minesweeper.CanIStartTheGame(boardLayout);
            Assert.True(canStartGame);
        }
        
        [Fact]
        public void ReturnException_FieldSizeTooSmall()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "00";
            var exception = Assert.Throws<Exception>(() => minesweeper.CanIStartTheGame(boardLayout));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }
    }
}