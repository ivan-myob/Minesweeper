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
        public void Return_IsRowSizeGreaterThan0()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var result = minesweeper.LengthOfRow(boardLayout);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void Return_IsColumnSizeGreaterThan0()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var result = minesweeper.LengthOfColumn(boardLayout);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void ReturnException_RowSizeTooSmall()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "00";
            var exception = Assert.Throws<Exception>(() => minesweeper.LengthOfRow(boardLayout));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }
        
        [Fact]
        public void ReturnException_ColumnSizeTooSmall()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "00";
            var exception = Assert.Throws<Exception>(() => minesweeper.LengthOfColumn(boardLayout));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }
        
        [Fact]
        public void Return_OutputOfJustStars4BY4()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("*........*......", finalOutput);
        }
        
        [Fact]
        public void Return_OutputOfJustStars3BY5()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "35\n**...\n.....\n.*...";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("**.........*...", finalOutput);
        }
        
        
/*        [Fact]
        public void Return_FinalOutputIsCorrect4BY4()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("*100\n2210\n1*10\n1110", finalOutput);
        }
        
        [Fact]
        public void Return_FinalOutputIsCorrect3BY5()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "35\n**...\n.....\n.*...";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("**100\n33200\n1*100", finalOutput);
        }*/
    }
}