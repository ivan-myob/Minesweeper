using System;

namespace Minesweeper
{
    public class Minesweeper
    {
        public static string FinalOutput(string boardLayout)
        {
            var finalOutput = "";
            StringLengthIsLongEnough(boardLayout);
            var dataFromBoardLayout = StringConversionThatIsRequired(boardLayout);
            var boardSizeRow = CalculationOfBoardSide(dataFromBoardLayout, 0);
            var boardSizeColumn = CalculationOfBoardSide(dataFromBoardLayout, 1);
            var needsNumbersBoard = FillTheCellsWithBoardLayout(dataFromBoardLayout, boardSizeRow, boardSizeColumn);
            var boardWithNumbers = FillTheCellsWithNumbers(needsNumbersBoard, boardSizeRow, boardSizeColumn);

            foreach (var cells in boardWithNumbers)
            {
                finalOutput += cells;
            }

            return finalOutput;
        }

        private static void StringLengthIsLongEnough(string boardLayout)
        {
            if (boardLayout.Length <= 3)
            {
                throw new Exception($"Please enter a larger field size");
            }
        }
        
        private static string StringConversionThatIsRequired(string boardLayout)
        {
            boardLayout = boardLayout.Replace("\n", "");
            boardLayout = boardLayout.Replace(".", "0");
            return boardLayout;
        }

        public static int CalculationOfBoardSide(string boardLayout, int rowOrColumn)
        {
            var boardSideLength = "";
            boardSideLength = boardSideLength + boardLayout[rowOrColumn];
            return Int32.Parse(boardSideLength);
        }
        
        private static string[,] FillTheCellsWithBoardLayout(string inputOfBoardLayout, int boardSizeRow, int boardSizeColumn)
        {
            var boardTable = new string[boardSizeRow, boardSizeColumn];
            var count = 2;

            for (int i = 0; i < boardSizeRow; i++)
            {
                for (int j = 0; j < boardSizeColumn; j++)
                {
                    boardTable[i, j] = inputOfBoardLayout[count++].ToString();
                }
            }
            return boardTable;
        }

        private static string[,] FillTheCellsWithNumbers(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn)
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

        private static string[,] FindOpenSpace(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn, int i, int j)
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