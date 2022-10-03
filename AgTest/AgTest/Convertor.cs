using AgTest.Interfaces;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgTest
{
    public class Convertor : IConvertor
    {
        private readonly IExcelDataReader _excelReader;
        public Convertor()
        {
        }
        public Convertor(IExcelDataReader iExcelDataReader)
        {
            _excelReader = iExcelDataReader;
        }
        public void ConvertExcelToXlsx(string file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            IExcelDataReader _excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet excel = _excelReader.AsDataSet();
            _excelReader.Close();

            string filename = excel.Tables[0].TableName.ToString();
            string csvData = "";
            int row_no = 0;
            bool yearFlag = false;

            while (row_no < excel.Tables[0].Rows.Count) 
            {
                if (excel.Tables[0].Rows[row_no][1].ToString() == "2022")
                {
                    yearFlag = true;
                    csvData = string.Empty;
                }
                if (yearFlag == true)
                {
                    for (int i = 0; i < excel.Tables[0].Columns.Count; i++)
                    {
                        csvData += excel.Tables[0].Rows[row_no][i].ToString() + ",";
                    }
                    if (excel.Tables[0].Rows[row_no + 1][1].ToString() == "2020")
                    {
                        break;
                    }
                }
                row_no++;
                csvData += "\n";
            }
            string fileName = filename + "CSV" + ".xlsx";
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\", fileName);
            //string output = @"C:\Users\aleks\Desktop\AgTest\" + filename + "CSV" + ".xlsx";
            StreamWriter csv = new StreamWriter(path, false);
            csv.Write(csvData);
            csv.Close();
            Console.Write("\nCsv file converted.\n");
        }
    }
}
