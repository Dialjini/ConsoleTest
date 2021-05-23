using System;
using System.Net;
using System.IO;

namespace ConsoleTest
{
    class Program
    {
        static int Controller()
        {
            Console.WriteLine("Введите номер тендера:");
            try
            {
                int number = Int32.Parse(Console.ReadLine()); // Явное приведение к Int32, если айди тендера в Int32
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Введеная строка не является числом."); // Если строка не является числом, рекурсивно вызываем контроллер
                return Controller();                                      // и возвращаем получившееся число.  
            }
        }
        static void Main(string[] args)
        {
            int tenderId = Controller(); // Вызываем контроллер
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(String.Format("https://market.mosreg.ru/Trade/ViewTrade/{0}", tenderId));
                Parser parser = new Parser();
                parser.Parse(response);
            }
        }
    }
}
