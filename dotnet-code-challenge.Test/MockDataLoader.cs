using Beteasy.RaceDataProviders.DataLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Test
{
    class MockDataLoader : IDataLoader
    {
        private string _text;

        public MockDataLoader(string fileName)
        {
            _text = File.ReadAllText(fileName);
        }

        public Task<string> LoadDataAsync(string dataId)
        {
            return Task.FromResult(_text);
        }
    }
}
