using System;

namespace Beteasy.RaceDataProviders
{
    public interface IHorseRaceDataProvider
    {
        HorseRace GetRaceData(string raceId);
    }
}
