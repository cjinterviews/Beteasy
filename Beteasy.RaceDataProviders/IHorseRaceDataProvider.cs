using System;
using System.Threading.Tasks;

namespace Beteasy.RaceDataProviders
{
    public interface IHorseRaceDataProvider
    {
        Task<HorseRace> GetRaceDataAsync(string raceId);
    }
}
