using System;

namespace ConsoleTest
{
    class Program
    {
        static void Controller()
        {
            Console.WriteLine("Введите номер тендера:");
            try
            {
                int number = Int32.Parse(Console.ReadLine()); // Явное приведение к Int32, если айди тендера в Int32
            }                                                 // В задании не уточняется Int32 или Int64
            catch (FormatException)
            {
                Console.WriteLine("Введеная строка не является числом."); // Если строка не является числом, рекурсивно вызываем контроллер
                Controller();
            }
        }
        static void Main(string[] args)
        {
            Controller(); // Вызываем контроллер
        }
    }
}
