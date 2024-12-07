using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LabIVT1
{
    internal class Lab4 : SupportForLab4
    {
        public void task1()
        {
            Console.WriteLine("Введите предложение, завершенное точкой");
            string input = Console.ReadLine();

            if (input == null || !input.EndsWith("."))
            {
                Console.WriteLine("Ошибка. Предложение должно заканчиваться точкой");
                return;
            }

            Console.WriteLine("Первый способ (обработка строки как массива символов)");
            FindUniqueCharactersUsingArray(input);

            Console.WriteLine("Второй способ (методы класса string)");
            FindUniqueCharactersUsingStringMethods(input);
        }

        public void task2()
        {
            Console.WriteLine("Введите предложение, завершенное точкой");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !input.EndsWith("."))
            {
                Console.WriteLine("Ошибка. Предложение должно заканчиваться точкой");
                return;
            }

            Console.WriteLine("Первый способ (обработка строки как массива символов)");
            string resultUsingArray = FormatStringUsingArray(input);
            Console.WriteLine(resultUsingArray);

            Console.WriteLine("Второй способ (методы класса string)");
            string resultUsingStringMethods = FormatStringUsingStringMethods(input);
            Console.WriteLine(resultUsingStringMethods);
        }

        public void task3()
        {
            Console.WriteLine("Введите предложение, завершенное точкой");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !input.EndsWith("."))
            {
                Console.WriteLine("Ошибка. Предложение должно заканчиваться точкой");
                return;
            }

            Console.WriteLine("Первый способ (обработка строки как массива символов)");
            string reversedUsingArray = ReverseWordsUsingArray(input);
            Console.WriteLine(reversedUsingArray);

            Console.WriteLine("Второй способ (классы string и StringBuilder)");
            string reversedUsingStringBuilder = (ReverseWordsUsingStringBuilder(input));
            Console.WriteLine(reversedUsingStringBuilder);
        }

        public void task4()
        {
            Console.WriteLine("Введите 7 строк текста");
            string[] lines = new string[7];
            for (int i = 0; i < 7; i++)
            {
                lines[i] = Console.ReadLine();
            }

            Console.WriteLine("Первый способ(обработка строки как массива символов)");
            FindLinesWithComAndMinSpacesUsingArray(lines);

            Console.WriteLine("Второй способ(методы класса string)");
            FindLinesWithComAndMinSpacesUsingStringMethods(lines);
        }

        public void task5()
        {
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            Console.WriteLine("Первый способ (обработка строки как массива символов)");
            FindWordsUsingArray(input);

            Console.WriteLine("Второй способ (испольхование регулярных выражений");
            FindWordsUsingRegex(input);

        }

        public void task6()
        {
            Console.WriteLine("Введите выражение вида 'число + число = число'");
            string input = Console.ReadLine();

            string pattern = @"\s*(-?\d+)\s*\+\s*(-?\d+)\s*=\s*(-?\d+)\s*";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                int operand1 = int.Parse(match.Groups[1].Value);
                int operand2 = int.Parse(match.Groups[2].Value);
                int result = int.Parse(match.Groups[3].Value);

                Console.WriteLine($"Первое число: {operand1}");
                Console.WriteLine($"Второе число: {operand2}");
                Console.WriteLine($"Результат: {result}");

                if (operand1 + operand2 == result)
                {
                    Console.WriteLine("Сумма правильная");
                }
                else
                {
                    Console.WriteLine("Ошибка, сумма неверна");
                }
            }
            else
            {
                Console.WriteLine("Ошибка, строка не соответствует заданному формату");
            }
        }

        public void task7()
        {
            string[] tracklist = {
                "Gentle Giant – Free Hand [6:15]",
                "Supertramp – Child Of Vision[07:27]",
                "Camel – Lawrence[10:46]",
                "Yes – Don’t Kill The Whale[3:55]",
                "10CC – Notell Hotel[04:58]",
                "Nektar – King Of Twilight[4:16]",
                "The Flower Kings – Monsters & Men[21:19]",
                "Focus – Le Clochard[1:59]",
                "Pendragon – Fallen Dream And Angel[5:23]", 
                "Kaipa – Remains Of The Day(08:02)"
            };

            List<Track> tracks = new List<Track>();
            int totalDuration = 0;

            string pattern = @"\[(\d+):(\d+)\]|\((\d+):(\d+)\)";

            foreach ( string line in tracklist )
            {
                Match match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    int minutes = int.Parse(match.Groups[1].Value != "" ? match.Groups[1].Value : match.Groups[3].Value);
                    int seconds = int.Parse(match.Groups[2].Value != "" ? match.Groups[2].Value : match.Groups[4].Value);

                    int durationInSeconds = minutes * 60 + seconds;
                    totalDuration += durationInSeconds;

                    tracks.Add(new Track(line,durationInSeconds));
                }
            }

            Track longestTrack = null;
            Track shortestTrack = null;
            foreach ( Track track in tracks )
            {
                if (longestTrack == null || track.DurationInSeconds > longestTrack.DurationInSeconds)
                {
                    longestTrack = track;
                }
                if (shortestTrack == null || track.DurationInSeconds < shortestTrack.DurationInSeconds)
                {
                    shortestTrack = track;
                }
            }

            Track minDiffTrack1 = null;
            Track minDiffTrack2 = null;
            int minDifference = int.MaxValue;

            for ( int i = 0; i < tracks.Count; i++ )
            {
                for ( int j = i + 1; j < tracks.Count; j++ )
                {
                    int difference = Math.Abs(tracks[i].DurationInSeconds - tracks[j].DurationInSeconds);
                    if ( difference < minDifference )
                    {
                        minDifference = difference;
                        minDiffTrack1 = tracks[i];
                        minDiffTrack2 = tracks[j];
                    }
                }
            }

            Console.WriteLine("Общее время звучания всех песен: " + FormatTime(totalDuration));
            Console.WriteLine("Самая длинная песня: " + longestTrack.Title + " (" + FormatTime(longestTrack.DurationInSeconds) + ")");
            Console.WriteLine("Самая короткая песня: " + shortestTrack.Title + " (" + FormatTime(shortestTrack.DurationInSeconds) + ")");
            Console.WriteLine("Пара песен с минимальной разницей во времени звучания");
            Console.WriteLine($"1. {minDiffTrack1.Title} ({FormatTime(minDiffTrack1.DurationInSeconds)})");
            Console.WriteLine($"2. {minDiffTrack2.Title} ({FormatTime(minDiffTrack2.DurationInSeconds)})");
            Console.WriteLine("Разница во времени: " + FormatTime(minDifference));
        }

        public void task8()
        {
            Console.WriteLine("Введите текс для шифрования/дешифрования(Шифр Атбаш)");
            string input1 = Console.ReadLine();
            
            string encryptedText = EncryptAtbash(input1);            
            Console.WriteLine("Зашифрованный текст (Атбаш): " + encryptedText);
            

            string decrpyptedText = EncryptAtbash(encryptedText);           
            Console.WriteLine("Расшифрованный текст (Атабш): " + decrpyptedText);
            

            Console.WriteLine("Введите текс для шифрования/дешифрования(Шифр Венрама)");
            string input2 = Console.ReadLine();
            Console.WriteLine("Введите ключ");
            string keyV = Console.ReadLine();
            if (keyV.Length != input2.Length)
            {
                Console.WriteLine("Ошибка, длина ключа должна быть равна длине текста");
                return;
            }

            encryptedText = EncryptVernam(input2, keyV);
            Console.WriteLine("Зашифрованный текст (Венрам): " + encryptedText);

            decrpyptedText = EncryptVernam(encryptedText, keyV);
            Console.WriteLine("Расшифрованный текст (Венрам): " + decrpyptedText);

            Console.WriteLine("Введите текс для шифрования/дешифрования(Шифр простой одинарной перестановки)");
            string input3 = Console.ReadLine();
            Console.WriteLine("Введите ключ");
            string keyP = Console.ReadLine();
            if (keyP.Length != input3.Length)
            {
                Console.WriteLine("Ошибка, длина ключа должна быть равна длине текста");
                return;
            }

            encryptedText = EncryptPermutation(input3, keyP);
            Console.WriteLine("Зашифрованный текст (Перестановка): " + encryptedText);

            decrpyptedText = EncryptPermutation(encryptedText, keyP);
            Console.WriteLine("Расшифрованный текст (Перестановка): " + decrpyptedText);
        }

        public void task9()
        {
            Console.WriteLine("Введите текст");
            string input = Console.ReadLine();

            string resultByArray = RemoveWordsByArrayMethods(input);
            Console.WriteLine("Результат (через массив символов)");
            Console.WriteLine(resultByArray);

            string resultByStringMethods = RemoveWordsByStringMethods(input);
            Console.WriteLine("Результат (через String и StringBuilder)");
            Console.WriteLine(resultByStringMethods);
        }

        public void task10()
        {
            Console.WriteLine("Введите текст");
            string input = Console.ReadLine();

            string datePattern = @"\b(\d{2})-(\d{2})-(\d{4})\b";

            MatchCollection matches = Regex.Matches(input, datePattern);

            Console.WriteLine("Найденные даты");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

            Console.WriteLine($"Всего найдено дат: {matches.Count}");
        }
    }
}
