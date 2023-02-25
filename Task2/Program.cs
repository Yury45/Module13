using Task1;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = @"C:\\Users\\Admin\\Downloads\\Text1.txt";

                if (File.Exists(filePath))
                {
                    var text = File.ReadAllText(filePath).RemovePunctions().ToLower();

                    var separators = new[] { ' ', '\n', '\r' };

                    var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    var dictionary = new Dictionary<string, int>();

                    foreach (var word in words)
                    {
                        if (!dictionary.ContainsKey(word))
                        {
                            dictionary.Add(word, 0);
                        }
                        dictionary[word]++;
                    }

                    var popularWord = dictionary
                        .Where(x => x.Key.Length > 2)   //Избавимся от коротких слов и предлогов
                        .OrderByDescending(x => x.Value)
                        .Take(10);

                    foreach (var node in popularWord)
                    {
                        Console.WriteLine($"Слово \"{node.Key}\" - количество вхождений {node.Value}");
                    }

                }
                else
                {
                    Console.WriteLine($"Ошибка: файл {filePath} не найден!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}