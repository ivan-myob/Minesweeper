using System;

namespace Minesweeper
{
    public class Minesweeper
    {
        public string FinalOutput(string boardLayout)
        {
            var boardSizeRow = LengthOfRow(boardLayout);
            var boardSizeColumn = LengthOfColumn(boardLayout);
            var finalOutput = "";

            for (int i = 0; i < boardSizeRow; i++)
            {
                for (int j = 0; j < boardSizeColumn; j++)
                {
                    return finalOutput;
                }
            }

            return finalOutput;
        }
        
        public int LengthOfRow(string boardLayout)
        {
            var boardSizeRow = "";
            if (boardLayout.Length > 2)
            {
                boardSizeRow = boardSizeRow + boardLayout[0];
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
                boardSizeColumn = boardSizeColumn + boardLayout[1];
            }
            else
            {
                throw new Exception($"Please enter a larger field size");
            }
            return Int32.Parse(boardSizeColumn);
        }
    }
}