using Beteasy.RaceDataProviders.DataLoader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beteasy.RaceDataProviders.Implementation
{
    internal class UkJsonRaceDataProvider : IHorseRaceDataProvider
    {
        private readonly IDataLoader dataLoader;

        public UkJsonRaceDataProvider(IDataLoader dataLoader)
        {
            this.dataLoader = dataLoader;
        }

        public async Task<HorseRace> GetRaceDataAsync(string raceId)
        {
            var jsonText = await dataLoader.LoadDataAsync(raceId);
            var model = JsonConvert.DeserializeObject<UkJsonRaceData>(jsonText);

            if (model?.RawData == null)
            {
                throw new RaceDataInvalidException("Source data missing RawData node");
            }
            if (model.RawData.Markets?.Count != 1)
            {
                // TODO: what if there are multiple markets? do we treat them seperately or combine their selections together? Ask the business
                throw new RaceDataInvalidException("Expected 1 market");
            }
            var market = model.RawData.Markets[0];

            var race = new HorseRace()
            {
                RaceName = model.RawData.FixtureName,
                _horses = market.Selections.Select(s => new Horse()
                {
                    HorseName = s.Tags.GetValueOrDefault("name"),
                    Price = s.Price
                }).ToList()
            };

            return race;
        }

    }
}
