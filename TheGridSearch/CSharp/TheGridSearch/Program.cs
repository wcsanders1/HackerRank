using System;
using System.Linq;

namespace TheGridSearch
{
    class Program
    {
        class Grid
        {
            public Grid(int rowCount, int columnCount)
            {
                PrivateGrid = new char[rowCount, columnCount];
            }

            private char[,] PrivateGrid { get; set; }
            public int RowCount => PrivateGrid.GetLength(0);
            public int ColumnCount => PrivateGrid.GetLength(1);

            public char this[int row, int column]
            {
                get => PrivateGrid[row, column];
                set
                {
                    PrivateGrid[row, column] = value;
                }
            }
        }

        static int[] GetRowsAndColumns(string rawRowsAndColumns)
        {
            return rawRowsAndColumns.Split(' ').Select(s => int.Parse(s)).ToArray();
        }

        static Grid GetGrid(int rowCount, int columnCount)
        {
            var grid = new Grid(rowCount, columnCount);

            for (var rowNumber = 0; rowNumber < rowCount; rowNumber++)
            {
                var newRow = Console.ReadLine().ToCharArray();
                for (var columnNumber = 0; columnNumber < columnCount; columnNumber++)
                {
                    grid[rowNumber, columnNumber] = newRow[columnNumber];
                }
            }

            return grid;
        }

        static bool PatternExists(int gridRow, int initialGridColumn, Grid grid, Grid pattern)
        {
            var gridColumn = initialGridColumn;

            for (var patternRow = 0; patternRow < pattern.RowCount; patternRow++)
            {
                if (gridRow >= grid.RowCount)
                {
                    return false;
                }

                for (var patternColumn = 0; patternColumn < pattern.ColumnCount; patternColumn++)
                {
                    if (gridColumn >= grid.ColumnCount)
                    {
                        return false;
                    }

                    if (grid[gridRow, gridColumn] != pattern[patternRow, patternColumn])
                    {
                        return false;
                    }

                    gridColumn++;
                    
                }

                gridRow++;
                gridColumn = initialGridColumn;
            }

            return true;
        }

        static string GetAnswer(Grid grid, Grid pattern)
        {
            for (var gridRow = 0; gridRow < grid.RowCount; gridRow++)
            {
                for (var gridColumn = 0; gridColumn < grid.ColumnCount; gridColumn++)
                {
                    if (PatternExists(gridRow, gridColumn, grid, pattern))
                    {
                        return "YES";
                    }
                }
            }
            return "NO";
        }

        static void Main()
        {
            var testCases = int.Parse(Console.ReadLine());
            for (var testCaseNumber = 0; testCaseNumber < testCases; testCaseNumber++)
            {
                var gridRowsAndColumns = GetRowsAndColumns(Console.ReadLine());
                var gridRowCount = gridRowsAndColumns[0];
                var gridColumnCount = gridRowsAndColumns[1];

                var grid = GetGrid(gridRowCount, gridColumnCount);

                var patternRowsAndColumns = GetRowsAndColumns(Console.ReadLine());
                var patternRowCount = patternRowsAndColumns[0];
                var patternColumnCount = patternRowsAndColumns[1];

                var pattern = GetGrid(patternRowCount, patternColumnCount);

                var answer = GetAnswer(grid, pattern);

                Console.WriteLine(answer);
            }
        }
    }
}
