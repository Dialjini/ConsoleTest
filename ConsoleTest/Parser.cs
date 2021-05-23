using System;
using System.Collections.Generic;
using AngleSharp;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Parser
    {
        public async Task Parse(string data)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            //var document = await context.OpenAsync(req => req.Content(data));
            //var blueListItemsCssSelector = document.QuerySelectorAll("class.informationAboutCustomer");
            var document = await context.OpenAsync(req => req.Content(data));

            //Do something with LINQ
            var blueListItemsCssSelector = document.QuerySelectorAll("div.informationAboutCustomer__informationPurchase");

            Console.WriteLine("Serializing the (original) document:");
            foreach (var item in blueListItemsCssSelector)
            {
                Console.WriteLine(item.TextContent);
            }
        }
    }
}
