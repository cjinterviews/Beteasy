using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Beteasy.RaceDataProviders.DataLoader
{
    class LocalFileDataLoader : IDataLoader
    {
        private readonly string fileExtension;

        public LocalFileDataLoader(string fileExtension)
        {
            this.fileExtension = fileExtension;
        }

        public async Task<string> LoadDataAsync(string dataId)
        {
            return await File.ReadAllTextAsync($@"FeedData\{dataId}.{fileExtension}");
        }
    }
}
