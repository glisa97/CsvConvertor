using AgTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace AgTest.Tests
{
    public class ConvertorTests
    {
        
        private readonly IConvertor _convertor;

        public ConvertorTests()
        {
            _convertor = Moq.Mock.Of<IConvertor>();
        }
        [Fact]
        public void ConvertorTest()
        {
            string file = @"C:\Users\aleks\Desktop\AgTest\TestFile.xlsx";
            _convertor.ConvertExcelToXlsx(file);
        }
    }
}
