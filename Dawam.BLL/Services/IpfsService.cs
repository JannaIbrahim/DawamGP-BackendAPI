using Dawam.BLL.Interfaces;
using Ipfs.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Services
{
    public class IpfsService : IIpfsService
    {
        private readonly IpfsClient _ipfsClient;

        public IpfsService(IpfsClient ipfsClient)
        {
            _ipfsClient = ipfsClient;
        }
        public Task DownloadFromIpfs(string ipfsHash, Stream outputStream)
        {
            //await _ipfsClient.FileSystem.DownloadAsync(ipfsHash, outputStream);
            throw new NotImplementedException();
        }

        public async Task<string> UploadToIpfs(Stream pdfStream)
        {
            var result = await _ipfsClient.FileSystem.AddAsync(pdfStream);
            return result.Id.Hash.ToString();
        }

        public async Task<byte[]> ReadPdfFileAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var pdfBytes = await response.Content.ReadAsByteArrayAsync();

            return pdfBytes;
        }
    }
}
