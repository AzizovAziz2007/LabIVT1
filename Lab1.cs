using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLabIVT1
{
    class Lab1
    {
        public void task1()
        {
            double x = 27.3198;
            string xStr = x.ToString();

            Console.WriteLine($"Указанное число {xStr}");

            int decimalPointIndex = xStr.IndexOf(',');
            if (decimalPointIndex != -1 && decimalPointIndex + 1 < xStr.Length)
            {
                char firstDigitOfFraction = xStr[decimalPointIndex + 1];
                int d = (int)char.GetNumericValue(firstDigitOfFraction);
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine("У числа нет дробной части");
            }
        }

        public void task2()
        {
            DateTime time = DateTime.Now;
            int hour = time.Hour;
            int minute = time.Minute;
            int second = time.Second;

            int totalSecond = (hour * 3600) + (minute * 60) + second;

            int hours = totalSecond / 3600;
            int minutes = (totalSecond % 3600) / 60;

            Console.WriteLine($"Часы: {hours}, Минуты: {minutes}");
        }

        public void task3()
        {
            Console.WriteLine("Введите (через Enter) значения h (часы), m (минуты) и s (секунды)");
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            if (h < 0 || h > 11 || m < 0 || m > 59 || s < 0 || s > 59)
            {
                Console.WriteLine("Ошибка ввода. Введите корректное время");
                return;
            }

            double hourAngle = (h % 12) * 30 + (m / 60.0) * 30 + (s / 3600) * 30;

            if (hourAngle > 180)
            {
                hourAngle = 360 - hourAngle;
            }

            Console.WriteLine($"Угол между положением часовой стрелки и началом суток: {hourAngle} градусов");
        }

        public void task4()
        {
            Console.WriteLine("Введите (через Enter) переменные a и b");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine($"До обмена: a = {a}, b = {b}");

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"После обмена:  a = {a}, b = {b}");
        }

        public void task5()
        {
            Console.WriteLine("Введите длину первого катета");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите длину второго катета");
            double b = double.Parse(Console.ReadLine());

            if (a <= 0 && b <= 0)
            {
                Console.WriteLine("Ошибка ввода. Катеты должны быть положительными");
                return;
            }

            double area = 0.5 * a * b;

            double c = Math.Sqrt(a * a + b * b);

            double perimetr = a + b + c;

            Console.WriteLine($"Площадь треугольника: {area}");
            Console.WriteLine($"Периметр треугольника: {perimetr}");
        }

        public void task6()
        {
            Console.WriteLine("Введите четырехзначное число");
            int number = int.Parse(Console.ReadLine());

            if (number < 1000 || number > 9999)
            {
                Console.WriteLine("Ошибка ввода. Число должно быть четырехзначным");
                return;
            }

            int product = 1;

            while (number > 0)
            {
                product *= number % 10;
                number /= 10;
            }

            Console.WriteLine($"Произведение цифр: {product}");
        }

        public void task7()
        {
            Console.WriteLine("Введите трехзначное число");
            int numder = int.Parse(Console.ReadLine());

            if (numder < 100 || numder > 999)
            {
                Console.WriteLine("Ошибка ввода. Число должно быть трехзначным");
                return;
            }

            string reversed = new string(numder.ToString().Reverse().ToArray());

            Console.WriteLine($"Обратное число: {reversed}");
        }

        public void task8()
        {
            Console.WriteLine("Введите действительное число x");
            double x = double.Parse(Console.ReadLine());

            double x2 = Math.Pow(x, 2);
            double x3 = Math.Pow(x, 3);
            double x4 = Math.Pow(x, 4);

            double result = 3 * x4 - 5 * x3 + 2 * x2 - x + 7;

            Console.WriteLine($"Ответ: {result}");
        }

        public void task9()
        {
            Console.WriteLine("Введите (через Enter) коэффициенты a1, b1, c1, d1");
            double a1 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double c1 = double.Parse(Console.ReadLine());
            double d1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите (через Enter) коэффициенты a2, b2, c2, d2");
            double a2 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double c2 = double.Parse(Console.ReadLine());
            double d2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите (через Enter) коэффициенты a3, b3, c3, d3");
            double a3 = double.Parse(Console.ReadLine());
            double b3 = double.Parse(Console.ReadLine());
            double c3 = double.Parse(Console.ReadLine());
            double d3 = double.Parse(Console.ReadLine());

            double determinant = a1 * (b2 * c3 - b3 * c2) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - a3 * b2);

            if (determinant == 0)
            {
                Console.WriteLine("Опрелелитель равен нулю. Система не имеет единственного решения");
                return;
            }

            double x = (d1 * (b2 * c3 - b3 * c2) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - d3 * b2)) / determinant;
            double y = (a1 * (d2 * c3 - d3 * c2) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - a3 * d2)) / determinant;
            double z = (a1 * (b2 * d3 - b3 * d2) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - a3 * b2)) / determinant;

            Console.WriteLine("Система уравнений:");
            Console.WriteLine($"{a1,5}x + {b1,5}y + {c1,5}z = {d1,5}");
            Console.WriteLine($"{a2,5}x + {b2,5}y + {c2,5}z = {d2,5}");
            Console.WriteLine($"{a2,5}x + {b2,5}y + {c2,5}z = {d2,5}");

            Console.WriteLine($"Решение: x = {x}, y = {y}, z = {z}");
        }

        private void PrintRow(string[] row)
        {
            foreach (var cell in row)
            {
                Console.Write($"| {cell,-20}");
            }
            Console.WriteLine("|");
        }

        private void PrintSeparator(int columns)
        {
            for (int i = 0; i < columns; i++)
            {
                Console.Write("+---------------------");
            }
            Console.WriteLine("+");
        }

        enum Post
        {
            П = 0,
            С = 1,
            А = 2,
        }

        struct Personnel
        {
            public string surname { get; set; }
            public Post post { get; set; }
            public int year { get; set; }
            public double salary { get; set; }
        }

        public void task10()
        {
            int rows = 3;
            int columns = 4;

            Personnel[] personnel = new Personnel[rows];

            string[] surnames = new string[] { "Иванов И.И.", "Петренко П.П.", "Сидоревич М.С." };
            Post[] posts = new Post[] { Post.П, Post.С, Post.А };
            int[] years = new int[] { 1975, 1996, 1990 };
            double[] salaries = new double[] { 4179.50, 790.10, 2200.00 };

            for (int i = 0; i < rows; i++)
            {
                personnel[i] = new Personnel();
                personnel[i].surname = surnames[i];
                personnel[i].post = posts[i];
                personnel[i].year = years[i];
                personnel[i].salary = salaries[i];
            }

            string[] headers = { "Фамилия", "Должность", "Год рожд", "Оклад (грн)" };
            PrintSeparator(columns);
            Console.WriteLine($"| {"Отдел кадров",-86}|");
            PrintSeparator(columns);

            string[,] table = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (j)
                    {
                        case 0:
                            table[i, j] = personnel[i].surname; break;
                        case 1:
                            table[i, j] = personnel[i].post.ToString(); break;
                        case 2:
                            table[i, j] = personnel[i].year.ToString(); break;
                        case 3:
                            table[i, j] = personnel[i].salary.ToString(); break;
                    }
                }
            }

            PrintRow(headers);
            PrintSeparator(columns);

            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[columns];
                for (int j = 0; j < columns; j++)
                {
                    row[j] = table[i, j];
                }
                PrintRow(row);
                PrintSeparator(columns);
            }
            Console.WriteLine($"| {"Перечисляемый тип: П - преподаватель, С - студент, А - аспирант",-86}|");
            PrintSeparator(columns);
        }

        public void task11()
        {
            Console.WriteLine("Введите (через Enter) значения a, b и x");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());

            double z = Math.Sqrt(a * x * Math.Sin(2 * x) + Math.Exp(-2 * x) * (x + b));
            double expression = a * x * Math.Sin(2 * x) + Math.Exp(-2 * x) * (x + b);

            if (expression < 0)
            {
                Console.WriteLine("Значение под корнем отрицательное!");
            }

            else
            {
                Math.Sqrt(expression);
                Console.WriteLine($"Значение z = {z}");
            }

            double w = Math.Pow(Math.Cos(x * x * x), 2) - x / Math.Sqrt(a * a + b * b);
            double denominator = Math.Sqrt(a * a + b * b);

            if (denominator == 0)
            {
                Console.WriteLine("Деление на ноль!");
            }

            else
            {
                Console.WriteLine($"Значение w = {w}");
            }
        }
    }
}
