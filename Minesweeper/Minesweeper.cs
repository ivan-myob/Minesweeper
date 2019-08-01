using System;

namespace Minesweeper
{
    public class Minesweeper
    {
        public void FinalOutput(string boardLayout)
        {
            int boardSizeColumn = 1;
            int boardSizeRow = 1;
            bool result = CanIStartTheGame(boardLayout);
        }
        
        public bool CanIStartTheGame(string boardLayout)
        {
            var boardSizeRow = 0;
            var boardSizeColumn = 0;

            if (boardLayout.Length > 2)
            {
                boardSizeRow = boardLayout[0];
                boardSizeColumn = boardLayout[1];
            }
            
            if (boardSizeRow > 0 && boardSizeColumn > 0)
            {
                return true;
            }
            throw new Exception($"Please enter a larger field size");
        }
    }
}