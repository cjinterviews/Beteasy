using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beteasy.RaceDataProviders.DataLoader
{
    public interface IDataLoader
    {
        Task<string> LoadDataAsync(string dataId);
    }
}
