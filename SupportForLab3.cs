﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabIVT1
{
    internal class SupportForLab3
    {
        protected void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        protected void RotateMatrix90Degrees(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;

                    int top = matrix[first, i];

                    matrix[first, i] = matrix[last - offset, first];

                    matrix[last - offset, first] = matrix[last, last - offset];

                    matrix[last, last - offset] = matrix[i, last];

                    matrix[i, last] = top;
                }
            }
        }

        protected void Reverse(int[] array, int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }

        protected void LeftRotate(int[] array, int k)
        {
            int n = array.Length;
            k = k % n;
            
            Reverse(array, 0, k-1);

            Reverse(array, k, n-1);

            Reverse(array, 0, n-1); 
        }

        protected int[,] AddMatrices(int[,] matrix1, int[,] matrix2, out double averange)
        {
            int size = 3;
            int[,] result = new int[size, size];
            int sum = 0;
            int totalElements = size * size * 2;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                    sum += matrix1[i, j] + matrix2[i, j];
                }
            }

            averange = (double)sum / totalElements;
            return result;
        }

        protected int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2, out double averange)
        {
            int size = 3;
            int[,] result = new int[size, size];
            int sum = 0;
            int totalElements = size * size * 2;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                    sum += matrix1[i, j] + matrix2[i, j];
                }
            }

            averange = (double)sum / totalElements;
            return result;
        }

        protected int[,] MultiplytMatrices(int[,] matrix1, int[,] matrix2)
        {
            int size = 5;
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += matrix1[i, j] * matrix2[i, j];
                    }
                }
            }

            return result;
        }

        protected int SumIterative(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum; 
        }

        protected int SumRecursive(int[] array, int index)
        {
            if (index < 0)
                return 0;
            return array[index] + SumRecursive(array, index - 1);
        }

        protected int MinIterative(int[] array)
        {
            int min = array[0];
            foreach (int num in array)
            {
                if (num < min)
                    min = num;
            }
            return min;
        }

        protected int MinRecursive(int[] array, int index)
        {
            if (index == 0)
                return array[0];
            int minOfRest = MinRecursive(array, index - 1);
            return array[index] < minOfRest ? array[index] : minOfRest;
        }

        protected int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private int[,] GetMinor(int[,] matrix, int size, int colToRemove)
        {
            int[,] minor = new int[size - 1, size - 1];
            int minorRow = 0, minorCol;

            for (int i = 1; i < size; i++)
            {
                minorCol = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == colToRemove) continue;

                    minor[minorRow, minorCol] = matrix[i, j];
                    minorCol++;
                }
                minorRow++;
            }
            return minor;
        }

        protected int CalculateDeterminant(int[,] matrix, int size)
        {
            if (size == 1)
            {
                return matrix[0, 0];
            }

            if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            int determinant = 0;
            int sign = 1;

            for (int col = 0; col < size; col++)
            {
                int[,] minor = GetMinor(matrix, size, col);

                determinant += sign * matrix[0, col] * CalculateDeterminant(minor, size - 1);

                sign = -sign;
            }
            return determinant;
        }

        protected void SymmetricDiagonalDisplay(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            Console.WriteLine("Главная и побочная диагонали, симметричено отображенные относительно вернтикальной оси");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j == size - 1 - i)
                    {
                        Console.Write($"{matrix[i, i], 4}");
                    }
                    else if (j == i)
                    {
                        Console.Write($"{matrix[i, size - 1 - i], 4}");
                    }
                    else
                    {
                        Console.Write("    ");
                    }
                }
                Console.WriteLine();
            }    
        }
    }
}
