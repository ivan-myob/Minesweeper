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
            var needsNumbersBoard = FillTheCellsWithBasicValues(inputOfBoardLayout, boardSizeRow, boardSizeColumn);
            var boardWithNumbers = FillTheCellsWithNumbers(needsNumbersBoard, boardSizeRow, boardSizeColumn);


            foreach (var cells in boardWithNumbers)
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

        public string[,] FillTheCellsWithBasicValues(string inputOfBoardLayout, int boardSizeRow, int boardSizeColumn)
        {
            // If cell is != * fill cell with 0
            // For each cell, if cell is == *, nehibour += 1

            var boardTable = new string[boardSizeRow, boardSizeColumn];
            var count = 2;

            for (int i = 0; i < boardSizeRow; i++)
            {
                for (int j = 0; j < boardSizeColumn; j++)
                {
                    if (inputOfBoardLayout[count].ToString() == "*")
                    {
                        boardTable[i, j] = inputOfBoardLayout[count].ToString();
                    }
                    else
                    {
                        boardTable[i, j] = "0";
                    }

                    count = count + 1;
                }
            }

            return boardTable;
        }

        public string[,] FillTheCellsWithNumbers(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn)
        {
            for (int i = 0; i < boardSizeRow; i++)
            {
                for (int j = 0; j < boardSizeColumn; j++)
                {
                    if (needsNumbersBoard[i, j] == "*")
                    {
                        FindOpenSpace(needsNumbersBoard, boardSizeRow, boardSizeColumn, i, j);
                    }
                }
            }

            return needsNumbersBoard;
        }

        public string[,] FindOpenSpace(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn, int i, int j)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if ((i + x >= 0 && j + y >= 0 && i + x < boardSizeRow && j + y < boardSizeColumn))
                    {
                        if ((needsNumbersBoard[(i + x), (j + y)]) == "3")
                        {
                            needsNumbersBoard[(i + x), (j + y)] = "4";
                        }
                        if ((needsNumbersBoard[(i + x), (j + y)]) == "2")
                        {
                            needsNumbersBoard[(i + x), (j + y)] = "3";
                        }
                        if ((needsNumbersBoard[(i + x), (j + y)]) == "1")
                        {
                            needsNumbersBoard[(i + x), (j + y)] = "2";
                        }
                        if ((needsNumbersBoard[(i + x), (j + y)]) == "0")
                        {
                            needsNumbersBoard[(i + x), (j + y)] = "1";
                        }
                    }
                }
            }
            return needsNumbersBoard;
        }
    }
}