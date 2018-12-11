using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders
{
    public interface IHorseRaceDataProviderFactory
    {
        IHorseRaceDataProvider GetHorseRaceDataProvider(string raceId);
    }
}
