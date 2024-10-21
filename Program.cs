using LabIVT1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите номер лабораторной работы");
        int N = int.Parse(Console.ReadLine());
        int n = 0;

        switch (N)
        {
            case 1:
                Lab1 lab1 = new Lab1();

                Console.WriteLine("Введите номер задания");
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Задание 1");
                        lab1.task1();
                        Console.ReadLine(); break;
                    case 2:
                        Console.WriteLine("Задание 2");
                        lab1.task2();
                        Console.ReadLine(); break;
                    case 3:
                        Console.WriteLine("Задание 3");
                        lab1.task3();
                        Console.ReadLine(); break;
                    case 4:
                        Console.WriteLine("Задание 4");
                        lab1.task4();
                        Console.ReadLine(); break;
                    case 5:
                        Console.WriteLine("Задание 5");
                        lab1.task5();
                        Console.ReadLine(); break;
                    case 6:
                        Console.WriteLine("Задание 6");
                        lab1.task6();
                        Console.ReadLine(); break;
                    case 7:
                        Console.WriteLine("Задание 7");
                        lab1.task7();
                        Console.ReadLine(); break;
                    case 8:
                        Console.WriteLine("Задание 8");
                        lab1.task8();
                        Console.ReadLine(); break;
                    case 9:
                        Console.WriteLine("Задание 9");
                        lab1.task9();
                        Console.ReadLine(); break;
                    case 10:
                        Console.WriteLine("Задание 10");
                        lab1.task10();
                        Console.ReadLine(); break;
                    case 11:
                        Console.WriteLine("Задание 11");
                        lab1.task11();
                        Console.ReadLine(); break;
                }
                break;
            case 2:
                Lab2 lab2 = new Lab2();

                Console.WriteLine("Введите номер задания");
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Задание 1");
                        lab2.task1();
                        Console.ReadLine(); break;
                    case 2:
                        Console.WriteLine("Задание 2");
                        lab2.task2();
                        Console.ReadLine(); break;
                    case 3:
                        Console.WriteLine("Задание 3");
                        lab2.task3();
                        Console.ReadLine(); break;
                    case 4:
                        Console.WriteLine("Задание 4");
                        lab2.task4();
                        Console.ReadLine(); break;
                    case 5:
                        Console.WriteLine("Задание 5");
                        lab2.task5();
                        Console.ReadLine(); break;
                    case 6:
                        Console.WriteLine("Задание 6");
                        lab2.task6();
                        Console.ReadLine(); break;
                    case 7:
                        Console.WriteLine("Задание 7");
                        lab2.task7();
                        Console.ReadLine(); break;
                    case 8:
                        Console.WriteLine("Задание 8");
                        lab2.task8();
                        Console.ReadLine(); break;
                }
                break;
        }   
    }
}