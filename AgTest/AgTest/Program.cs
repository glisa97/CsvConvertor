using ExcelDataReader;
using System;
using System.Data;
using System.IO;
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

            string fileName = "Excel.xlsx";
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\", fileName);
            //string file = @"C:\Users\aleks\Desktop\AgTest\Excel.xlsx";
            Uri url = new Uri("https://bakerhughesrigcount.gcs-web.com/static-files/e106a3e4-ddd8-4e7d-93a3-01c3de9e7ac0");

            await downloader.Download(url, path);
            convertor.ConvertExcelToXlsx(path);

            Console.WriteLine("\nFile is in Convertor folder.\n");
        }
    }
}
