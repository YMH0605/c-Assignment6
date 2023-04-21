using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IBlobService
	{
        public Task<BlobResponseModel> GetBlobAsync(string name);
        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}

