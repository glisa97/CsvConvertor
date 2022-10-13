using ExcelDataReader;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            FIleDownloader downloader = new FIleDownloader();
            Convertor convertor = new Convertor();

            string baseAddress = "https://bakerhughesrigcount.gcs-web.com";
            string fileName = "HtmlPage.html";
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\", fileName);

            Uri url = new Uri(baseAddress + "/intl-rig-count?c=79687&p=irol-rigcountsintl");

            await downloader.Download(url, path, fileName);

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc = htmlWeb.Load(path);

            foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                string titleValue = node.GetAttributeValue("title", string.Empty);

                if (titleValue == "Worldwide Rig Count Sep 2022.xlsx") 
                {
                    string hrefValue = String.Concat(baseAddress, node.GetAttributeValue("href", string.Empty));
                    url = new Uri(hrefValue);
                }
            }
            fileName = "Excel.xlsx";
            path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\", fileName);
            await downloader.Download(url, path,fileName);

            convertor.ConvertExcelToXlsx(path);

            Console.WriteLine("\nFiles are in main folder.\n");
        }
    }
}
