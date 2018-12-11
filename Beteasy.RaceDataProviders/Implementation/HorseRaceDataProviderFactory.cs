using Beteasy.RaceDataProviders.DataLoader;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beteasy.RaceDataProviders.Implementation
{
    // TODO: Change to internal once we've set all this up with a DI container
    public class HorseRaceDataProviderFactory : IHorseRaceDataProviderFactory
    {
        public IHorseRaceDataProvider GetHorseRaceDataProvider(string raceId)
        {
            // TODO: Determine how to tell which provider gives us the data for a given race
            // This is a short-term hack as we need to check how this will work
            if (raceId.StartsWith("Caul"))
            {
                return new AusXmlRaceDataProvider(new LocalFileDataLoader("xml"));
            }
            else
            {
                return new UkJsonRaceDataProvider(new LocalFileDataLoader("json"));
            }
        }
    }
}
