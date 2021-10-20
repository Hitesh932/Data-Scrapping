using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace Scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://hulk4x4.com.au//products/vehicle-protection/rubber-fender-flare-kit-3-5/");
            var HeaderNames = doc.DocumentNode.SelectNodes("//h3[@class='sku']");
            var titles = new List<Row>();
            foreach (var item in HeaderNames)
            {
              titles.Add(new Row { Title = item.InnerText});
            }
           using (var writer = new StreamWriter("C:\\ITPlusPoint\\Test.csv"))
           using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
           {
            csv.WriteRecords(titles);
           }
        }
    }
       public class Row
      {
         public string Title {get; set;}
      }
}
