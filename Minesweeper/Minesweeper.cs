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
            return int.Parse(boardSideLength);
        }
        
        private static string[,] FillTheCellsWithBoardLayout(string dataFromBoardLayout, int boardSizeRow, int boardSizeColumn)
        {
            var boardTable = new string[boardSizeRow, boardSizeColumn];
            var count = 2;
            for (var currentRow = 0; currentRow < boardSizeRow; currentRow++)
            {
                for (var currentColumn = 0; currentColumn < boardSizeColumn; currentColumn++)
                {
                    boardTable[currentRow, currentColumn] = dataFromBoardLayout[count++].ToString();
                }
            }
            return boardTable;
        }

        private static string[,] FillTheCellsWithNumbers(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn)
        {
            for (var currentRow = 0; currentRow < boardSizeRow; currentRow++)
            {
                for (var currentColumn = 0; currentColumn < boardSizeColumn; currentColumn++)
                {
                    if (needsNumbersBoard[currentRow, currentColumn] == "*")
                    {
                        IncreaseNumberInCellIfMineAround(needsNumbersBoard, boardSizeRow, boardSizeColumn, currentRow, currentColumn);
                    }
                }
            }
            return needsNumbersBoard;
        }

        private static string[,] IncreaseNumberInCellIfMineAround(string[,] needsNumbersBoard, int boardSizeRow, int boardSizeColumn, int currentRow, int currentColumn)
        {
            for (var minePointerRow = -1; minePointerRow <= 1; minePointerRow++)
            {
                for (var minePointerColumn = -1; minePointerColumn <= 1; minePointerColumn++)
                {
                    if ((currentRow + minePointerRow >= 0 && currentColumn + minePointerColumn >= 0 && currentRow + minePointerRow < boardSizeRow && currentColumn + minePointerColumn < boardSizeColumn))
                    {
                        if ((needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)]) == "3")
                        {
                            needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)] = "4";
                        }
                        if ((needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)]) == "2")
                        {
                            needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)] = "3";
                        }
                        if ((needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)]) == "1")
                        {
                            needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)] = "2";
                        }
                        if ((needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)]) == "0")
                        {
                            needsNumbersBoard[(currentRow + minePointerRow), (currentColumn + minePointerColumn)] = "1";
                        }
                    }
                }
            }
            return needsNumbersBoard;
        }
    }
}