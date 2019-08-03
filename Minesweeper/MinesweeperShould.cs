using System;
using Xunit;

namespace Minesweeper
{
    public class MinesweeperShould
    {
        [Fact]
        public void Return_IsRowSizeGreaterThan0()
        {
            var boardLayout = $"44{Environment.NewLine}*...{Environment.NewLine}....{Environment.NewLine}.*..{Environment.NewLine}....";
            var rowOrColumn = 0;
            var result = Minesweeper.CalculationOfBoardSide(boardLayout, rowOrColumn);
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void Return_IsColumnSizeGreaterThan0()
        {
            var boardLayout = $"44{Environment.NewLine}*...{Environment.NewLine}....{Environment.NewLine}.*..{Environment.NewLine}....";
            var rowOrColumn = 1;
            var result = Minesweeper.CalculationOfBoardSide(boardLayout, rowOrColumn);
            Assert.Equal(4, result);
        }
        
/*        [Fact]
        public void ReturnException_RowSizeTooSmall()
        {
            var boardLayout = "00";
            var rowOrColumn = 0;
            var exception = Assert.Throws<Exception>(() => Minesweeper.CalculationOfBoardSide(boardLayout, rowOrColumn));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }
        
        [Fact]
        public void ReturnException_ColumnSizeTooSmall()
        {
            var boardLayout = "00";
            var rowOrColumn = 0;
            var exception = Assert.Throws<Exception>(() => Minesweeper.CalculationOfBoardSide(boardLayout, rowOrColumn));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }*/
        
        [Fact]
        public void ReturnException_StringSizeTooSmall()
        {
            var minesweeper = new Minesweeper();
            var boardLayout = "00";
            var exception = Assert.Throws<Exception>(() => Minesweeper.FinalOutput(boardLayout));
            Assert.Equal("Please enter a larger field size", exception.Message);
        }

        
/*        [Fact]
        public void Return_OutputOfJustSingleNumber4BY4()
        {
            var boardLayout = "44\n*...\n....\n.*..\n....";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("*10011101*101110", finalOutput);
        }
        
        [Fact]
        public void Return_OutputOfJustSingleNumber3BY5()
        {
            var boardLayout = "35\n**...\n.....\n.*...";
            var finalOutput = minesweeper.FinalOutput(boardLayout);
            Assert.Equal("**100111001*100", finalOutput);
        }*/
        
        
        [Fact]
        public void Return_FinalOutputIsCorrect4BY4()
        {
            var boardLayout = $"44{Environment.NewLine}*...{Environment.NewLine}....{Environment.NewLine}.*..{Environment.NewLine}....";
            var finalOutput = Minesweeper.FinalOutput(boardLayout);
            Assert.Equal("*10022101*101110", finalOutput);
        }
        
        [Fact]
        public void Return_FinalOutputIsCorrect3BY5()
        {
            var boardLayout = $"35{Environment.NewLine}**...{Environment.NewLine}.....{Environment.NewLine}.*...";
            var finalOutput = Minesweeper.FinalOutput(boardLayout);
            Assert.Equal("**100332001*100", finalOutput);
        }
    }
}