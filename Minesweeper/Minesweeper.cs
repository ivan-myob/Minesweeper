using System;

namespace Minesweeper
{
    public class Minesweeper
    {
        public string FinalOutput(string boardLayout)
        {
            var inputOfBoardLayout = boardLayout.Replace("\n", "");
            var boardSizeRow = LengthOfRow(inputOfBoardLayout);
            var boardSizeColumn = LengthOfColumn(inputOfBoardLayout);
            var finalOutput = "";
            foreach (var cells in FillTheCellsWithValues(inputOfBoardLayout, boardSizeRow, boardSizeColumn))
            {
              finalOutput += cells;   
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

        public string[,] FillTheCellsWithValues(string inputOfBoardLayout, int boardSizeRow, int boardSizeColumn)
        {
            // If cell is != * fill cell with 0
            // For each cell, if cell is == *, nehibour += 1
            
            var boardTable = new string[boardSizeRow, boardSizeColumn];
            var count = 2;
            
            for (int i = 0; i < boardSizeRow; i++)
            {
                for (int j = 0; j < boardSizeColumn; j++)
                {
                    boardTable[i, j] = inputOfBoardLayout[count].ToString();
                    count = count + 1;
                }
            }

            return boardTable;

            //var nearbyPanels = Panels.Where(panel => panel.X >= (x - depth) && panel.X <= (x + depth)
            //&& panel.Y >= (y - depth) && panel.Y <= (y + depth));
            //var currentPanel = Panels.Where(panel => panel.X == x && panel.Y == y);
        }
    }
}