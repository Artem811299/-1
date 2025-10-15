using System;
using System.Linq;

namespace MatrixPractice2
{
    public class MatrixOperations
    {
        public static bool IsInShadedArea(int row, int col, int totalRows, int totalCols)
        {
            return row < totalRows / 2;
        }

        public static int CountNegativeInShadedArea(double[,] matrix)
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (IsInShadedArea(i, j, rows, cols) && matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static double[] CreateArrayFromShadedArea(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (IsInShadedArea(i, j, rows, cols))
                    {
                        count++;
                    }
                }
            }

            double[] result = new double[count];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (IsInShadedArea(i, j, rows, cols))
                    {
                        result[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            return result;
        }

        public static double[] MultiplyColumnsInShadedArea(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] products = new double[cols];

            for (int j = 0; j < cols; j++)
            {
                products[j] = 1;
                bool hasElements = false;

                for (int i = 0; i < rows; i++)
                {
                    if (IsInShadedArea(i, j, rows, cols))
                    {
                        products[j] *= matrix[i, j];
                        hasElements = true;
                    }
                }

                if (!hasElements)
                {
                    products[j] = 0;
                }
            }
            return products;
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
                    Console.
Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            int cols = 4;

            double[,] matrix = MatrixOperations.InputMatrix(rows, cols);
            MatrixOperations.PrintMatrix(matrix);

            int negativeCount = MatrixOperations.CountNegativeInShadedArea(matrix);
            Console.WriteLine($"\n1) Количество отрицательных элементов в заштрихованной области: {negativeCount}");

            double[] shadedArray = MatrixOperations.CreateArrayFromShadedArea(matrix);
            Console.WriteLine("2) Массив из элементов заштрихованной области: " +
                            string.Join(", ", shadedArray));

            double[] columnProducts = MatrixOperations.MultiplyColumnsInShadedArea(matrix);
            Console.WriteLine("3) Произведения по столбцам в заштрихованной области: " +
                            string.Join(", ", columnProducts));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}