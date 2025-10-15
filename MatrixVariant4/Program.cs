using System;
using System.Linq;

namespace MatrixVariant4
{
    public class MatrixOperations
    {
        public static int CountElementsEqualToSix(double[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 6)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int CountNegativeInLastColumn(double[,] matrix)
        {
            int count = 0;
            int lastColumn = matrix.GetLength(1) - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, lastColumn] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int[] CountPositiveInEachRow(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int[] positiveCounts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                positiveCounts[i] = count;
            }
            return positiveCounts;
        }

        public static double[] CreateArrayFromNegativeElements(double[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            double[] result = new double[count];
            int index = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        result[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            return result;
        }

        public static double[,] InputMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Console.WriteLine($"Введите матрицу {rows}x{cols}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        public static void PrintMatrix(double[,] matrix)
        {
            Console.WriteLine("\nМатрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 4;

            double[,] matrix = MatrixOperations.InputMatrix(rows, cols);
            MatrixOperations.PrintMatrix(matrix);

            int countSix = MatrixOperations.CountElementsEqualToSix(matrix);
            Console.WriteLine($"\n1) Количество элементов, равных 6: {countSix}");

            int negativeLastCol = MatrixOperations.CountNegativeInLastColumn(matrix);
            Console.WriteLine($"2) Количество отрицательных в последнем столбце: {negativeLastCol}");

            int[] positiveCounts = MatrixOperations.CountPositiveInEachRow(matrix);
            Console.WriteLine("3) Массив T (количество положительных по строкам): " +
                            string.Join(", ", positiveCounts));

            double[] negativeElements = MatrixOperations.CreateArrayFromNegativeElements(matrix);
            Console.WriteLine("4) Массив D (отрицательные элементы): " +
                            string.Join(", ", negativeElements));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}