using System;
using System.Collections.Generic;
using AngleSharp;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Parser
    {
        public async Task<PartTwo> Parse(string data)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(req => req.Content(data));
            PartTwo result = new PartTwo();
            var addressSelector = document.QuerySelectorAll("div.informationAboutCustomer__informationPurchase"); // CSS selector

            foreach (var item in addressSelector)
            {
                result.address = item.TextContent.Split("����� ��������:\n")[1].Split("\n")[0].Trim(' '); // ������� ������
                result.name = item.TextContent.Split("������������:\n")[1].Split("\n")[0].Trim(' '); // ������� ������������
            }

            var lotSelector = document.QuerySelectorAll("div.outputResults__oneResult"); // CSS selector
            foreach (var item in lotSelector)
            {
                Lot lot = new Lot();

                lot.name = item.TextContent.Split("������������ ������, �����, �����: ")[1].Split("\n")[0]; // ������� ���������� � �����
                lot.price = float.Parse(item.TextContent.Split("��������� ������� ��������� ( � �.�. ��� ��� �������): ")[1].Split("\n")[0]);
                lot.unit = item.TextContent.Split("������� ���������: ")[1].Split("\n")[0];
                lot.count = float.Parse(item.TextContent.Split("����������: ")[1].Split("\n")[0]);
                result.lot.Add(lot);
            }
            return result;
        }
    }
}
