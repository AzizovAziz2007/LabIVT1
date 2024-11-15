using LabIVT1;
using System.Reflection;

internal class Program
{
    static void InvokeMethodByName(object obj, string methodName, params object[] parametrs)
    {
        Type type = obj.GetType();

        MethodInfo method = type.GetMethod(methodName);
        
        if (method != null)
        {
            method.Invoke(obj, parametrs);
        }
        else
        {
            Console.WriteLine($"Метод с именем {methodName} не найден");
        }
    }
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

                Console.WriteLine($"Задание {n}");
                InvokeMethodByName(lab1, "task" + n);
                break;
            case 2:
                Lab2 lab2 = new Lab2();

                Console.WriteLine("Введите номер задания");
                n = int.Parse(Console.ReadLine());

                Console.WriteLine($"Задание {n}");
                InvokeMethodByName(lab2, "task" + n);
                break;
            case 3:
                Lab3 lab3 = new Lab3();

                Console.WriteLine("Введите номер задания");
                n = int.Parse(Console.ReadLine());

                Console.WriteLine($"Задание {n}");
                InvokeMethodByName(lab3, "task" + n);
                break;

        }   
    }
}