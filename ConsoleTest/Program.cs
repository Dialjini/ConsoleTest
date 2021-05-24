using System;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded"; 
                // Отправляем POST запрос и приводим к классу PartOne
                pt1 = JsonSerializer.Deserialize<PartOne>(
                    webClient.UploadString("https://api.market.mosreg.ru/api/Trade/GetTradesForParticipantOrAnonymous", data));

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

        static List<PartThree> PtThree(int tenderId)
        {
            var pt3 = new List<PartThree>();
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и приводим к PartThree классу
                pt3 = JsonSerializer.Deserialize<List<PartThree>>(
                    webClient.DownloadString(String.Format("https://api.market.mosreg.ru/api/Trade/{0}/GetTradeDocuments", tenderId)));
                
            }
            return pt3;
        }

        static void Main()
        {
            int tenderId = Controller(); // Вызываем контроллер

            // Part 1
            PartOne pt1_response = PtOne(tenderId);
            try
            {
                Invdata pt1 = pt1_response.invdata[0];

                string beautyfulTradeState = String.Format("{0} (1)", pt1.TradeStateName, pt1.TradeState);

                // Part 2
                PartTwo pt2 = PtTwo(tenderId);

                // Part 3
                List<PartThree> pt3 = PtThree(tenderId);

                // Result compilation
                OutputData result = new OutputData(tenderId, pt2.name, beautyfulTradeState,
                    pt1.CustomerFullName, pt1.InitialPrice, pt1.PublicationDate, pt1.FillingApplicationEndDate,
                    pt2.address, pt2.lot, pt3);
                result.PrintResult(result);
                Main(); // Рекурсивный вызов после окончания работы очередного цикла
            }

            catch (System.ArgumentOutOfRangeException) // Исключение для некорректного номера тендера
            {
                Console.WriteLine("Несуществующий номер тендера.");
                Main(); // Рекурсивно запускаю снова, удобней чем каждый раз запускать приложение вручную
            }
        }
    }
}
