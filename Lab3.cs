using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabIVT1
{
    internal class Lab3 : SupportForLab3
    {
        public void task1()
        {
            Console.WriteLine("Введите количество элементов массива");
            int arraySize = int.Parse(Console.ReadLine());

            int[] array = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(-30, 46);
            }

            Console.WriteLine("\nСгенерированный массив:");
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"{array[i],4}");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("\nПоложительные элементы массива в обратном порядке:");
            for (int i = arraySize - 1; i >= 0; i--)
            {
                if (array[i] > 0)
                {
                    Console.Write($"{array[i],4}");
                }
            }
            Console.WriteLine();
        }

        public void task2()
        {
            int size = 7;
            int[,] matrix = new int[size, size];

            int counter = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = counter++;
                }
            }

            Console.WriteLine("Оригинальный мвссив:");
            PrintMatrix(matrix);

            RotateMatrix90Degrees(matrix);

            Console.WriteLine("\nМассив после поворота на 90 градусов впрово:");
            PrintMatrix(matrix);
        }

        public void task3()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("Введите количество позиций для сдвига влево");
            int k = int.Parse(Console.ReadLine());

            LeftRotate(array, k);

            Console.WriteLine("Массив после циклического сдвига влево");
            Console.WriteLine(string.Join(" ", array));
        }

        public void task4()
        {
            int[,] matrix1 = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            };

            int[,] matrix2 = {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 },
            };

            double averange;

            int[,] sumMatrix = AddMatrices(matrix1, matrix2, out averange);
            Console.WriteLine("Результат сложения матриц");
            PrintMatrix(sumMatrix);
            Console.WriteLine($"Среднее значение всех элементов входных матриц: {averange:F2}");

            int[,] diffMatrix = SubtractMatrices(matrix1, matrix2, out averange);
            Console.WriteLine("Результат сложения матриц");
            PrintMatrix(diffMatrix);
            Console.WriteLine($"Среднее значение всех элементов входных матриц: {averange:F2}");
        }

        public void task5()
        {
            int[,] matrix1 = {
                { 1, 2, 3, 4, 5},
                { 6, 7 , 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            int[,] matrix2 = {
                { 25, 24, 23, 22, 21 },
                { 20, 19, 18, 17, 16 },
                { 15, 14, 13, 12, 11 },
                { 10, 9 ,8, 7, 6 },
                { 5, 4, 3, 2, 1 }
            };

            int[,] resultMatrix = MultiplytMatrices(matrix1, matrix2);

            Console.WriteLine("Результат перемножения матриц");
            PrintMatrix(resultMatrix);
        }

        public void task6()
        {
            int[] array = { 5, 12, -4, 7, 3, -9, 15, 8 };

            Console.WriteLine("Массив: " + string.Join(", ", array));

            Console.WriteLine("Сумма элементов массива (итеративно): " + SumIterative(array));
            Console.WriteLine("Сумма элементов массива (рекурсивно): " + SumRecursive(array, array.Length - 1));

            Console.WriteLine("Минимальный элемент массива (итеративно): " + MinIterative(array));
            Console.WriteLine("Минимальный элемент массива (рекурсивно): " + MinRecursive(array, array.Length - 1));
        }

        public void task7()
        {
            Console.WriteLine("Введите номер элемента ряда Фибоначчи");
            int n = int.Parse(Console.ReadLine());

            int result = Fibonacci(n);
            Console.WriteLine($"{n}-й член ряда Фибоначчи: {result}");
        }

        public void task8()
        {
            Console.Write("Введите размерность матрицы N (NxN): ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            Console.WriteLine("Введите элементы матрицы");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int determinant = CalculateDeterminant(matrix, n);
            Console.WriteLine($"Определитель матрицы: {determinant}");
        }

        public void task9()
        {
            int size = 9;
            int[,] matrix = new int[size, size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(1, 100);
                }
            }
            Console.WriteLine("Исходная матрица");
            PrintMatrix(matrix);

            SymmetricDiagonalDisplay(matrix);
        }

        public void task10()
        {
            int N;

            while (true)
            {
                Console.WriteLine("Введите четное количество элементов массива");
                N = int.Parse(Console.ReadLine());

                if (N > 0 && N % 2 == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введите положительное число!");
                }
            }

            int[] array = new int[N];
            Console.WriteLine("Введите элементы массива");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Элемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            bool isIncreasing = true;
            for (int i = 0; i < N - 1; i++)
            {
                if (array[i] >= array[i + 1])
                {
                    isIncreasing = false;
                    break;
                }
            }
            Console.WriteLine(isIncreasing ? "TRUE" : "FALSE");
        }
    }
}



