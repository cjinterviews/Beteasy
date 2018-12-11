using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Beteasy.RaceDataProviders.DataLoader
{
    class LocalFileDataLoader : IDataLoader
    {
        public async Task<string> LoadDataAsync(string dataId)
        {
            return await File.ReadAllTextAsync($@"FeedData\{dataId}.json");
        }
    }
}
