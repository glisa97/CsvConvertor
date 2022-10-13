using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgTest.Interfaces
{
    public interface IFileDownloader
    {
        Task Download(Uri url, string file, string fileName);
    }
}
