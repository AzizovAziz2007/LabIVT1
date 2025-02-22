internal class Program
{
    public enum Post { П, С, А, Неизвестен }

    struct Personnel
    {
        public string surname;
        public Post post;
        public int year;
        public double salary;

        public void DisplayInfo()
        {
            Console.WriteLine($"{surname,-20} {post,-20} {year,-20} {salary,-21}");
        }
    }

    struct Log
    {
        public string surname;
        public DateTime time;
        public string operation;

        public void DisplayLog()
        {
            Console.WriteLine($"{time,-20} {operation,-20} {surname,-20}");
        }
    }

    public static void Main(string[] args)
    {
        Personnel Ivanov;
        Ivanov.surname = "Иванов И.И.";
        Ivanov.post = Post.П;
        Ivanov.year = 1975;
        Ivanov.salary = 4170.50;

        Personnel Petrenko;
        Petrenko.surname = "Петренко П.П.";
        Petrenko.post = Post.С;
        Petrenko.year = 1996;
        Petrenko.salary = 790.10;

        Personnel Sidorevich;
        Sidorevich.surname = "Сидоревич М.С.";
        Sidorevich.post = Post.А;
        Sidorevich.year = 1990;
        Sidorevich.salary = 2200.00;

        var Table = new List<Personnel>();
        Table.Add(Ivanov);
        Table.Add(Petrenko);
        Table.Add(Sidorevich);

        var Log = new List<Log>();
        DateTime time_1 = DateTime.Now;
        DateTime time_2 = DateTime.Now;
        TimeSpan timeInterval_1 = time_2 - time_1;

        string Menu = "\n1 – Просмотр таблицы \n2 – Добавить запись \n3 – Удалить запись \n4 – Обновить запись \n5 – Поиск записей \n6 – Просмотреть лог \n7 – Выход\n";
        bool optionError = true;

        do
        {
            Console.WriteLine(Menu);
            int Option = int.Parse(Console.ReadLine());
            switch (Option)
            {
                case 1:
                    for (int i = 0; i < Table.Count; i++)
                    {
                        Table[i].DisplayInfo();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введите фамилию: ");
                        string surname = Console.ReadLine();

                        Console.WriteLine("Введите должность:  (П - преподаватель, С - студент, А - аспирант)");
                        var post = Post.Неизвестен;
                        bool postError = false;
                        do
                        {
                            string choicePost = Console.ReadLine();

                            if (choicePost == "П")
                            {
                                post = Post.П;
                                postError = false;

                            }
                            else if (choicePost == "С" || choicePost == "C")
                            {
                                post = Post.С;
                                postError = false;
                            }
                            else if (choicePost == "А" || choicePost == "A")
                            {
                                post = Post.А;
                                postError = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите правильную должность! (П - преподаватель, С - студент, А - аспирант)");
                                postError = true;
                            }
                        }
                        while (postError == true);

                        Console.WriteLine("Введите год рождения: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.WriteLine("Введите оклад");
                        double salary = double.Parse(Console.ReadLine());

                        Personnel newPersonnel;
                        newPersonnel.surname = surname;
                        newPersonnel.post = post;
                        newPersonnel.year = year;
                        newPersonnel.salary = salary;
                        Table.Add(newPersonnel);

                        Log newLog;
                        newLog.surname = surname;
                        newLog.time = DateTime.Now;
                        newLog.operation = "Запись добавлена!";
                        Log.Add(newLog);

                        time_1 = DateTime.Now;
                        TimeSpan timeInterval_2 = time_1 - time_2;
                        if (timeInterval_1 < timeInterval_2)
                        {
                            timeInterval_1 = timeInterval_2;
                        }
                        time_2 = newLog.time;
                    }
                    break;
                case 3:
                    {
                        Console.Write("Введите номер записи: ");

                        bool deleteError = false;
                        do
                        {
                            deleteError = false;

                            int choiceNumberDelete = int.Parse(Console.ReadLine());
                            if (choiceNumberDelete > 0 && choiceNumberDelete < Table.Count)
                            {
                                Log newDelete;
                                newDelete.surname = Table[choiceNumberDelete - 1].surname;
                                newDelete.time = DateTime.Now;
                                newDelete.operation = "Запись удалена!";
                                Log.Add(newDelete);
                                Table.RemoveAt(choiceNumberDelete - 1);

                                time_1 = DateTime.Now;
                                TimeSpan timeInterval_2 = time_1 - time_2;
                                if (timeInterval_1 < timeInterval_2)
                                {
                                    timeInterval_1 = timeInterval_2;
                                }
                                time_2 = newDelete.time;
                            }
                            else
                            {
                                Console.WriteLine("Введите правильный номер! (1, 2, 3, 4, 5, 6, 7)");
                                deleteError = true;
                            }
                        }
                        while (deleteError == true);
                    }
                    break;
                case 4:
                    {
                        Console.Write("Введите номер записи: ");

                        bool changeError = false;
                        do
                        {
                            int choiceNumberChange = int.Parse(Console.ReadLine());
                            if (choiceNumberChange > 0 && choiceNumberChange < Table.Count)
                            {
                                string oldSurname = Table[choiceNumberChange - 1].surname;
                                Console.WriteLine("Введите новую фамилию: ");
                                string surname = Console.ReadLine();
                                if (surname == String.Empty)
                                {
                                    surname = oldSurname;
                                }

                                var oldPost = Table[choiceNumberChange - 1].post;
                                Console.WriteLine("Введите новую должность: (П - преподаватель, С - студент, А - аспирант)");
                                var post = Post.Неизвестен;

                                bool postError = false;
                                do
                                {
                                    string choicePost = Console.ReadLine();

                                    if (choicePost == "П")
                                    {
                                        post = Post.П;
                                        postError = false;

                                    }
                                    else if (choicePost == "С" || choicePost == "C")
                                    {
                                        post = Post.С;
                                        postError = false;
                                    }
                                    else if (choicePost == "А" || choicePost == "A")
                                    {
                                        post = Post.А;
                                        postError = false;
                                    }
                                    else if (choicePost == String.Empty)
                                    {
                                        post = oldPost;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите правильную должность! (П - преподаватель, С - студент, А - аспирант)");
                                        postError = true;
                                    }
                                }
                                while (postError == true);

                                int oldYear = Table[choiceNumberChange - 1].year;
                                Console.WriteLine("Введите новый год рождения: ");
                                int year = int.Parse(Console.ReadLine());
                                if (year == 0)
                                {
                                    year = oldYear;
                                    changeError = false;
                                }

                                double oldSalary = Table[choiceNumberChange - 1].salary;
                                Console.WriteLine("Введите новый оклад: ");
                                double salary = double.Parse(Console.ReadLine());
                                if (salary == 0)
                                {
                                    salary = oldSalary;
                                    changeError = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Введите правильный номер! (1, 2, 3, 4, 5, 6, 7)");
                            }
                        }
                        while (changeError == true);
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("Введите должность: (П - преподаватель, С - студент, А - аспирант)");

                        bool seatchError = false;
                        do
                        {
                            Char choiceNumberSearch = Convert.ToChar(Console.ReadLine());
                            if (choiceNumberSearch == 'П')
                            {
                                var records = Table.FindAll(i => i.post == Post.П);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                                seatchError = false;
                            }
                            else if (choiceNumberSearch == 'С' || choiceNumberSearch == 'C')
                            {
                                var records = Table.FindAll(i => i.post == Post.С);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                                seatchError = false;
                            }
                            else if (choiceNumberSearch == 'А' || choiceNumberSearch == 'A')
                            {
                                var records = Table.FindAll(i => i.post == Post.А);
                                foreach (var record in records)
                                {
                                    record.DisplayInfo();
                                }
                                seatchError = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите правильную должность! (П - преподаватель, С - студент, А - аспирант)");
                                seatchError = true;
                            }
                        }
                        while (seatchError == true);
                    }
                    break;
                case 6:
                    {
                        for (int i = 0; i < Log.Count; i++)
                        {
                            Log[i].DisplayLog();
                        }
                        Console.WriteLine();
                        Console.WriteLine(timeInterval_1 + " - Самый долгий период бездействия пользователя");
                    }
                    break;
                case 7:
                    {
                        optionError = false;
                    }
                    break;
                default:
                    Console.WriteLine("Введите правильную команду!");
                    optionError = true;
                    break;
            }
        }
        while (optionError);
    }
}
