using System.Diagnostics;

namespace Task1
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

                    var list = new List<string>();
                    var linkedList = new LinkedList<string>();

                    var timer = new Stopwatch();

                    timer.Start();
                    foreach (var word in words)
                    {
                        list.Add(word);
                    }

                    Console.WriteLine(timer.Elapsed.TotalMilliseconds + " миллисекунд <List>");

                    timer.Restart();

                    foreach (var word in words)
                    {
                        linkedList.AddLast(word);
                    }

                    Console.WriteLine(timer.Elapsed.TotalMilliseconds + " миллисекунд <LinkedList>");
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