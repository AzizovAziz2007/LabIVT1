using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabIVT1
{
    internal class SupportForLab4
    {
        protected void FindUniqueCharactersUsingArray(string text)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }

            foreach (var item in charCount)
            {
                if (item.Value == 1)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }

        protected void FindUniqueCharactersUsingStringMethods(string text)
        {
            var uniqueChars = text
                .Where(c => char.IsLetterOrDigit(c))
                .GroupBy(c => c)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key);
            foreach (char c in uniqueChars)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();
        }

        protected string FormatStringUsingArray(string text)
        {
            StringBuilder result = new StringBuilder();
            int wordCount = 0;
            bool inWord = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetterOrDigit(c))
                {
                    if (!inWord)
                    {
                        wordCount++;
                        inWord = true;
                        result.Append(c);
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
                else
                {
                    if (inWord)
                    {
                        result.Append($"({wordCount})");
                        inWord = false;
                    }
                    result.Append(c);
                }
            }

            if (inWord)
            {
                result.Append($"({wordCount})");
            }

            return result.ToString();
        }

        protected string FormatStringUsingStringMethods(string text)
        {
            string textWithoutPeriod = text.TrimEnd('.');

            string[] words = Regex.Split(textWithoutPeriod, @"(\s+|,|-)");

            StringBuilder result = new StringBuilder();
            int wordCount = 0;

            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word) && Regex.IsMatch(word, @"\w+"))
                {
                    wordCount++;
                    result.Append($"{word}({wordCount})");
                }
                else
                {
                    result.Append(word);
                }
            }

            result.Append(".");
            return result.ToString();
        }

        protected string ReverseWordsUsingArray(string text)
        {
            text = text.TrimEnd('.');
            char[] charArray = text.ToCharArray();
            StringBuilder word = new StringBuilder();
            StringBuilder result = new StringBuilder();
            var words = new System.Collections.Generic.List<string>();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != ' ')
                {
                    word.Append(charArray[i]);
                }
                else if (word.Length > 0)
                {
                    words.Add(word.ToString());
                    word.Clear();
                }
            }

            if (word.Length > 0)
            {
                words.Add(word.ToString());
            }

            for (int i = words.Count - 1; i >= 0; i--)
            {
                result.Append(words[i]);
                if (i != 0)
                {
                    result.Append(" ");
                }
            }

            result.Append(".");
            return result.ToString();
        }

        protected string ReverseWordsUsingStringBuilder(string text)
        {
            text = text.TrimEnd('.');
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);

            StringBuilder result = new StringBuilder();
            result.Append(string.Join(" ", words));
            result.Append(".");

            return result.ToString();
        }

        protected void FindLinesWithComAndMinSpacesUsingArray(string[] lines)
        {
            int minSpacesIndex = -1;
            int minSpaceCount = int.MaxValue;

            Console.WriteLine("Строки, содержащие хотя бы одно слово, оканчивающееся на .com");
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                bool hasComWord = false;
                int spaceCount = 0;
                int wordEnd = -1;

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == ' ')
                    {
                        spaceCount++;
                    }

                    if (j >= 3 && line[j - 3] == '.' && line.Substring(j - 2, 3).ToLower() == "com")
                    {
                        hasComWord = true;
                    }

                    if (spaceCount < minSpaceCount)
                    {
                        minSpaceCount = spaceCount;
                        minSpacesIndex = i;
                    }
                }

                if (hasComWord)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine($"Номер строки с наименьшим числом пробелов: {minSpacesIndex + 1}");
        }

        protected void FindLinesWithComAndMinSpacesUsingStringMethods(string[] lines)
        {
            int minSpacesIndex = -1;
            int minSpaceCount = int.MaxValue;

            Console.WriteLine("Строки, содержащие хотя бы одно слово, оканчивающееся на .com");
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (Regex.IsMatch(line, @"\b\w+\.com\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(line);
                }

                int spaceCount = line.Split(' ').Length - 1;
                if (spaceCount < minSpaceCount)
                {
                    minSpaceCount = spaceCount;
                    minSpacesIndex = i;
                }
            }

            Console.WriteLine($"Номер строки с наименьшим числом пробелов: {minSpacesIndex + 1}");
        }

        protected void FindWordsUsingArray(string text)
        {
            var words = new System.Collections.Generic.List<string>();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetterOrDigit(c))
                {
                    word.Append(c);
                }
                else
                {
                    if (word.Length > 0 && IsValidWord(word.ToString()))
                    {
                        words.Add(word.ToString());
                    }
                    word.Clear();
                }
            }

            if (word.Length > 0 && IsValidWord(word.ToString()))
            {
                words.Add(word.ToString());
            }

            Console.WriteLine("Найденный слова");
            foreach (var foundWord in words)
            {
                Console.WriteLine(foundWord);
            }
        }

        protected bool IsValidWord(string word)
        {
            if (word.Length >= 3 &&
                char.IsUpper(word[0]) &&
                char.IsDigit(word[^1]) &&
                char.IsDigit(word[^2]))
            {
                return true;
            }
            return false;
        }

        protected void FindWordsUsingRegex(string text)
        {
            string pattern = @"\b[A-Z][a-zA-Z]*\d{2}\b";
            MatchCollection matches = Regex.Matches(text, pattern);

            Console.WriteLine("Найденные слова");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        public class Track
        {
            public string Title { get; set; }
            public int DurationInSeconds { get; set; }

            public Track(string title, int durationInSeconds)
            {
                Title = title;
                DurationInSeconds = durationInSeconds;
            }
        }

        protected string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }

        protected string EncryptAtbash(string text)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        result.Append((char)('A' + ('Z' - c)));
                    }
                    else if (char.IsLower(c))
                    {
                        result.Append((char)('a' + ('z' - c)));
                    }
                    else if (c >= 'А' && c <= 'Я')
                    {
                        result.Append((char)('А' + ('Я' - c)));
                    }
                    else if (c >= 'а' && c <= 'я')
                    {
                        result.Append((char)('а' + ('я' - c)));
                    }
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        protected string EncryptVernam(string text, string key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char textChar = char.ToUpper(text[i]);
                char keyChar = char.ToUpper(key[i]);

                char encryptedChar = (char)(text[i] ^ key[i]);
                result.Append(encryptedChar);
            }

            return result.ToString();

        }

        protected string EncryptPermutation(string text, string key)
        {
            char[] result = new char[text.Length];
            int[] keyArray = Array.ConvertAll(key.Split(' '), int.Parse);

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = text[keyArray[i] - 1];
            }

            return new string(result);
        }

        protected string RemoveWordsByArrayMethods(string text)
        {
            StringBuilder result = new StringBuilder();
            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                char firstChar = char.ToLower(word[0]);
                char lastChar = char.ToLower(word[word.Length - 1]);

                if (firstChar != lastChar)
                {
                    result.Append(word + " ");
                }
            }

            return result.ToString().Trim();
        }

        protected string RemoveWordsByStringMethods(string text)
        {
            StringBuilder result = new StringBuilder();
            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (char.ToLower(word[0]) != char.ToLower(word[word.Length - 1]))
                {
                    result.Append(word).Append(" ");
                }
            }

            return result.ToString().Trim();
        }
    }
}
