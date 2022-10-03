using AgTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgTest.Tests
{
    public class FileDownloaderTests
    {
        private readonly IFileDownloader _fileDownloader;

        public FileDownloaderTests()
        {
            _fileDownloader = Moq.Mock.Of<IFileDownloader>();
        }
        [Fact]
        public async Task FileDownloaderTest()
        {
            string file = @"C:\Users\aleks\Desktop\AgTest\TestFile.xlsx";
            Uri url = new Uri("https://bakerhughesrigcount.gcs-web.com/static-files/e106a3e4-ddd8-4e7d-93a3-01c3de9e7ac0");
            await _fileDownloader.Download(url, file);
        }
    }
}
