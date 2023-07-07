using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Interfaces
{
    public interface IIpfsService
    {
        public Task<string> UploadToIpfs(Stream pdfStream);
        public Task DownloadFromIpfs(string ipfsHash, Stream outputStream);
        public Task<byte[]> ReadPdfFileAsync(HttpClient client, string url);

    }
}
