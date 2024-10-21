using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabIVT1
{
    internal class Lab2
    {
        public void task1()
        {
            Console.WriteLine("Решаем уравнение вида ax^2 + bx + c = 0");
            Console.WriteLine("Введите (через Enter) числа a, b и c");
            double a = double.Parse(Console.ReadLine());
            
            if (a == 0)
            {
                Console.WriteLine("Некорректный ввод числа: a не может равняться 0");
                return;
            }

            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a == 1 & b == 0 & c == 0)
            {
                Console.WriteLine("Получили уравнение x^2 = 0");
            }

            else if (a == 1 & b == 1 & c == 0)
            {
                Console.WriteLine("Получили уравнение x^2 + x = 0");
            }

            else if (a == 1 & b == -1 & c == 0)
            {
                Console.WriteLine("Получили уравнение x^2 + -x = 0");
            }

            else if (a == -1 & b == 0 & c == 0)
            {
                Console.WriteLine("Получили уравнение -x^2 = 0");
            }

            else if (a == -1 & b == 1 & c == 0)
            {
                Console.WriteLine("Получили уравнение -x^2 + x = 0");
            }

            else if (a == -1 & b == -1 & c == 0)
            {
                Console.WriteLine("Получили уравнение -x^2 + -x = 0");
            }

            else if (a == 1 & b == 0)
            {
                Console.WriteLine($"Получили уравнение x^2 + {c} = 0");
            }

            else if (a == 1 & b == 1)
            {
                Console.WriteLine($"Получили уравнение x^2 + x + {c} = 0");
            }

            else if (a == 1 & b == -1)
            {
                Console.WriteLine($"Получили уравнение x^2 + -x + {c} = 0");
            }

            else if (a == -1 & b == 0)
            {
                Console.WriteLine($"Получили уравнение -x^2 + {c} = 0");
            }

            else if (a == -1 & b == 1)
            {
                Console.WriteLine($"Получили уравнение -x^2 + x + {c} = 0");
            }

            else if (a == -1 & b == -1)
            {
                Console.WriteLine($"Получили уравнение -x^2 + -x + {c} = 0");
            }

            else
            {
                Console.WriteLine($"Получили уравнение {a}x^2 + {b}x + {c} = 0");
            }           

            double D = b * b - 4 * a * c;

            if (D > 0)
            {
                Console.WriteLine($"Дискриминант больше 0 (D = {D}). Уравнение имеет два действительных корня");
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");    
            }

            if (D == 0)
            {
                Console.WriteLine($"Дискриминант равен 0 (D = {D}). Уравнение имеет один действительный корень");
                double x = -b / (2 * a);

                if (b == 0 & c == 0)
                {
                    Console.WriteLine($"Корень уравнения: x = 0");
                }

                else
                {
                    Console.WriteLine($"Корень уравнения: x = {x}");
                }
            }

            if (D < 0)
            {
                Console.WriteLine($"Дискриминант меньше 0 (D = {D}). Уравнение имеет два мнимых корня");
                D = Math.Abs(D);               
                double x = (-b / (2 * a));
                D = Math.Sqrt(D) / (2 * a);
                
                if (b == 0)
                {
                    Console.WriteLine($"Корни уравнения: x1 = {D}i, x2 = {D}i");
                }                
                
                else
                {
                    Console.WriteLine($"Корни уравнения: x1 = {x} + {D}i, x2 = {x} - {D}i");
                }
            }
        }

        public void task2()
        {
            int count = 0;
            Console.WriteLine("Введите кол-во слагаемых для вычисления Pi");
            count = int.Parse(Console.ReadLine());

            if (count <= 0)
            {
                Console.WriteLine("Число слагаемых должно быть больше 0");
                return;
            }

            double pi = 0;
            double tmp = 0;

            int step = 1;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    tmp = 1;
                }

                else
                {
                    tmp = (i % 2 == 0) ?
                    tmp + (double)(1.0 / step) :
                    tmp - (double)(1.0 / step);
                }
                    
                Console.WriteLine($"#{i} tmp = {tmp} step = {step}");
                step += 2;
            }    

            pi = 4 * tmp;
            Console.WriteLine($"Результат вычисления Pi = {pi}");
        }

        public void task3()
        {
            int count = 0;
            Console.WriteLine("Введите число операций");
            count = int.Parse(Console.ReadLine());

            double[] f = new double[count];

            double count4 = 0;

            for (int i = 0; i < count; i++)
            {
                if (i < 2)
                {
                    f[i] = 1;
                }
                    
                else
                {
                    f[i] = f[i - 1] + f[i - 2];
                }
                    
                if (f[i] >= 1000 && f[i] <= 9999)
                {
                    count4++;
                }
                
                Console.WriteLine($"Шаг {i} f = {f[i]}");
            }
            Console.WriteLine($"Всего 4-х значных значений: {count4}");               
        }

        private int facrotial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
        public void task4()
        {
            Console.WriteLine("Введите (через Enter) числа x и q");
            int x = int.Parse(Console.ReadLine());
            double q = double.Parse(Console.ReadLine());

            double tmp = 0;
            int step = 2;
            do
            {
                if (step == 2)
                {
                    tmp = 1;
                }

                else
                {
                    tmp = step % 4 != 0 ?
                        tmp - (Math.Pow(x, step) / facrotial(step)) :
                        tmp + (Math.Pow(x, step) / facrotial(step));
                }
                Console.WriteLine($"Шаг = {step} вычисление = {tmp} < {q}");
                step += 2;

            } while (tmp >= q);
        }

        public void task5()
        {
            int N;

            Console.WriteLine("Введите N (N>0)");
            N = int.Parse(Console.ReadLine());

            double result;

            bool find = false;

            int x = 0, y = 0, z = 0;

            for (x = 0; x < N; x++)
            {
                for (y = 0; y < N; y++)
                {
                    for (z = 0; z < N; z++)
                    {
                        result = Math.Pow(x,3) + Math.Pow(y,3) + Math.Pow(z,3);
                      
                        if (result == N)
                        {
                            if (x == 0 || y == 0 || z == 0)
                            {
                                Console.WriteLine("Ничего не найдено!");
                                return;
                            }
                                                     
                            else
                            {
                                Console.WriteLine($"{x}^3+{y}^3+{z}^3={N}");

                                find = true;
                            }                            
                        }                        
                    }
                }
            }
            
            if ( !find )
            {
                Console.WriteLine("Ничего не найдено!");
            }
        }

        public void task6()
        {
            int age = 0;

            Console.WriteLine("Введите возраст");
            age = int.Parse(Console.ReadLine());

            if (age < 1 || age >= 100)
            {
                Console.WriteLine("Неверный ввод");
                return;
            }

            string ageTmp = "";
            if (age == 0 || age % 10 == 0 || age >= 5 && age <= 19 || age % 10 >= 5)
            {
                ageTmp = "лет";
            }

            if ((age % 10 == 1 || age == 1) && (age < 10 || age > 20))
            {
                ageTmp = "год";
            }

            if (age % 10 == 2 || age % 10 == 3 || age % 10 == 4)
            {
                ageTmp = "года";
            }

            Console.WriteLine($"Вам {age} {ageTmp}");
        }

        public void task7()
        {
            Console.WriteLine("Введите (через Enter) координаты точки");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            string quarter = "";

            if (x > 0 & y > 0)
            {
                quarter = "I";
            }

            if (x < 0 & y > 0)
            {
                quarter = "II";
            }

            if (x < 0 & y < 0)
            {
                quarter = "III";
            }

            if (x > 0 & y < 0)
            {
                quarter = "IV";
            }

            if (x == 0 || y == 0)
            {
                Console.WriteLine($"Одна из координат точки ({x};{y}) равна нулю. Точка не находится ни в одной четверти");
                return;
            }

            else
            {                
                if (quarter == "II")
                {
                    Console.WriteLine($"Точка ({x};{y}) находится вo {quarter} четверти");
                }

                else
                {
                    Console.WriteLine($"Точка ({x};{y}) находится в {quarter} четверти");
                }
            }
        }

        public void task8()
        {
            Console.WriteLine("Введите число от 1 до 10000");
            int a = int.Parse(Console.ReadLine());

            if ( a < 1 || a > 10000)
            {
                Console.WriteLine("Введено некорректное число");
                return; 
            }

            bool find = false;
            for (int i = 1; i < a; i++)
            {
                if (a % i == 0 && i % 2 ==0)
                {
                    find = true;
                    Console.WriteLine($"Четный делитель числа {a}: {i} ");
                }              
            }

            if (!find)
            {
                Console.WriteLine($"Четные делители числа {a} отсутствуют ");
            }
        }
    }
}
