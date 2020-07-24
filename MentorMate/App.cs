using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MentorMate
{
	class App
	{
		public void Run() 
		{
			ushort columns = 0;
			ushort rows = 0;

			Input input = new Input();
			do
			{
				Console.WriteLine("Please, enter the dimensions of the grid where: x (width) <= y (height) < 1000");
				columns = input.ReadGridDimension('X');
				rows = input.ReadGridDimension('Y');
			} while (columns > rows);

			byte[,] generationZero = input.ReadGenerationZero(columns, rows);

			ushort x1 = input.ReadX1(columns);
			ushort y1 = input.ReadY1(rows);
			ushort n = input.ReadN();

            Grid grid = new Grid();

            byte[,] previousGeneration = generationZero;
            byte[,] nextGeneration;
            ushort counter = 0;
            // if the cell is green count it
            if (generationZero[y1, x1] == 1) counter++;

            for (int i = 0; i < n; i++) // the number of generations
            {
                nextGeneration = grid.GetNextGeneration(previousGeneration);
                if (nextGeneration[y1, x1] == 1) counter++;
                previousGeneration = nextGeneration;
            }


            Console.WriteLine($"{columns}, {rows}");
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(generationZero[i, j]);
                }
            }

            Console.WriteLine($"\n{x1}, {y1}, {n}");

            Console.WriteLine($"Result: {counter}");
        }
	}
}
