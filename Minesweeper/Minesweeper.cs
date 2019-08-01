using System;

namespace Minesweeper
{
    public class Minesweeper
    {
        public void FinalOutput(string boardLayout)
        {
            var boardSizeRow = LengthOfRow(boardLayout);
            var boardSizeColumn = LengthOfColumn(boardLayout);
        }
        
        public int LengthOfRow(string boardLayout)
        {
            var boardSizeRow = "";
            if (boardLayout.Length > 2)
            {
                boardSizeRow = boardLayout.Substring(0,1);
            }
            else
            {
                throw new Exception($"Please enter a larger field size");
            }
            return Int32.Parse(boardSizeRow);
        }
        
        public int LengthOfColumn(string boardLayout)
        {
            var boardSizeColumn = "";
            if (boardLayout.Length > 2)
            {
                boardSizeColumn = boardLayout.Substring(0,1);
            }
            else
            {
                throw new Exception($"Please enter a larger field size");
            }
            return Int32.Parse(boardSizeColumn);
        }
    }
}