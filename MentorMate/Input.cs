using System;
namespace MentorMate
{

    public class Input
    {

        public ushort ReadGridDimension(char dimensionName)
        {
            ushort dimension = 0;
            bool result = false;
            do
            {
                Console.Write($"Please, enter dimension {dimensionName}: ");
                result = ushort.TryParse(Console.ReadLine(), out dimension);
            } while (result == false || dimension >= 1000);
            return dimension;
        }

        public byte[,] ReadGenerationZero(ushort columns, ushort rows)
        {

            byte[,] generationZero = new byte[rows, columns];
            string row;
            bool isRowCorrect = true;
            byte symbol;

            for (int i = 0; i < rows; i++)
            {
                do
                {
                    Console.Write($"Please enter {columns} characters for row {i}. Only character 0 and 1 allowed (e.g 0100): ");
                    row = Console.ReadLine();
                    if (row.Length != columns) continue;

                    for (int j = 0; j < columns; j++)
                    {
                        if (!byte.TryParse(row[j].ToString(), out symbol))
                        {
                            isRowCorrect = false;
                            break;
                        }

                        if (symbol != 0 && symbol != 1)
                        {
                            isRowCorrect = false;
                            break;
                        }
                        generationZero[i, j] = symbol;
                    }
                } while (row.Length != columns || !isRowCorrect);
            }

            //byte[,] test = new byte[2, 3] { // 2 - the number of the rows 3 the number of columns
            //    { 1,0,1 },
            //    { 1,1,1 }
            //};

            return generationZero;
        }

        public ushort ReadX1(ushort x)
        {
            ushort x1 = 0;
            bool result = false;
            do
            {
                Console.Write($"Please, enter x1 (from 0 to {x}): ");
                result = ushort.TryParse(Console.ReadLine(), out x1);
            } while (result == false || x1 > x);
            return x1;
        }

        public ushort ReadY1(ushort y)
        {
            ushort y1 = 0;
            bool result = false;
            do
            {
                Console.Write($"Please, enter y1 (from 0 to {y}): ");
                result = ushort.TryParse(Console.ReadLine(), out y1);
            } while (result == false || y1 > y);
            return y1;
        }

        public ushort ReadN()
        {
            ushort n = 0;
            bool result = false;
            do
            {
                Console.Write($"Please, enter N (smaller than 1000): ");
                result = ushort.TryParse(Console.ReadLine(), out n);
            } while (result == false || n > 1000);
            return n;
        }
    }
}
