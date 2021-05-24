using System;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        static PartOne PtOne(int tenderId)
        {
            PartOne pt1 = new PartOne();
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                string data = String.Format("page=1&itemsPerPage=10&Id={0}", tenderId);
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded"; // Отправляем POST запрос и приводим к классу PartOne
                var reply = JsonSerializer.Deserialize<PartOne>(webClient.UploadString("https://api.market.mosreg.ru/api/Trade/GetTradesForParticipantOrAnonymous", data));
                Console.WriteLine(reply);

            }
            return pt1;
        }

        static PartTwo PtTwo(int tenderId)
        {
            PartTwo pt2 = new PartTwo();
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(String.Format("https://market.mosreg.ru/Trade/ViewTrade/{0}", tenderId));
                Parser parser = new Parser();
                pt2 = parser.Parse(response).GetAwaiter().GetResult();
            }

            return pt2; 
        }


        static void Main(string[] args)
        {
            int tenderId = Controller(); // Вызываем контроллер
            // Part 1
            PartOne pt1 = PtOne(tenderId);
            // Part 2
            PartTwo pt2 = PtTwo(tenderId);
            
        }
    }
}
