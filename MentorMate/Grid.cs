using System;
using System.Collections.Generic;
using System.Text;

namespace MentorMate
{
    class Grid
    {
        public byte[,] GetNextGeneration(byte[,] previousGeneration)
        {
            byte[,] nextGeneration = new byte[previousGeneration.GetLength(0), previousGeneration.GetLength(1)];

            for (ushort i = 0; i < previousGeneration.GetLength(0); i++) //rows
            {
                for (ushort j = 0; j < previousGeneration.GetLength(1); j++) // columns
                {
                    nextGeneration[i, j] = DetermineColor(previousGeneration, i, j);
                }
            }

            return nextGeneration;
        }

        public byte DetermineColor(byte[,] grid, ushort row, ushort column) // y row x column
        {
            byte color = grid[row, column]; // the initial color of the cell
            
            ushort numberOfGreenNeighbours = 0;
           
            numberOfGreenNeighbours = GetNumberOfNeighbours(grid, row, column, 1);

            // red cell
            if (grid[row, column] == 0 && (numberOfGreenNeighbours == 3 || numberOfGreenNeighbours == 6))
            {
                color = 1;
            }

            // green cell
            if (grid[row, column] == 1 && (
                numberOfGreenNeighbours == 0
                || numberOfGreenNeighbours == 1
                || numberOfGreenNeighbours == 4
                || numberOfGreenNeighbours == 5
                || numberOfGreenNeighbours == 7
                || numberOfGreenNeighbours == 8))
            {
                color = 0;
            }


            return color;
        }

        public ushort GetNumberOfNeighbours(byte[,] grid, ushort row, ushort column, byte color)
        {
            ushort counter = 0;

            // upper left
            if (row >= 1 && column >= 1 && grid[row - 1, column - 1] == color) counter++;
            // upper middle
            if (row >= 1 && grid[row - 1, column] == color) counter++;
            // upper right
            if (row >= 1 && column < grid.GetLength(1) - 1 && grid[row - 1, column + 1] == color) counter++;
            // to the right
            if (column < grid.GetLength(1) - 1 && grid[row, column + 1] == color) counter++;
            // bottom right
            if (row < grid.GetLength(0) - 1 && column < grid.GetLength(1) - 1 && grid[row + 1, column + 1] == color) counter++;
            // bottom middle
            if (row < grid.GetLength(0) - 1 && grid[row + 1, column] == color) counter++;
            // bottom left
            if (row < grid.GetLength(0) - 1 && column >= 1 && grid[row + 1, column - 1] == color) counter++;
            // to the left
            if (column >= 1 && grid[row, column - 1] == color) counter++;

            return counter;
        }
    }
}
