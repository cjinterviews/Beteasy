using Beteasy.RaceDataProviders.DataLoader;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Beteasy.RaceDataProviders.Implementation
{
    internal class AusXmlRaceDataProvider : IHorseRaceDataProvider
    {
        private readonly IDataLoader dataLoader;

        public AusXmlRaceDataProvider(IDataLoader dataLoader)
        {
            this.dataLoader = dataLoader;
        }

        public async Task<HorseRace> GetRaceDataAsync(string raceId)
        {
            var xmlText = await dataLoader.LoadDataAsync(raceId);
            if (string.IsNullOrWhiteSpace(xmlText))
            {
                throw new RaceDataInvalidException("Empty document provided");
            }

            var xdoc = XDocument.Parse(xmlText);

            var raceElements = xdoc.XPathSelectElements("/meeting/races/race");
            var raceNode = raceElements.SingleOrDefault();
            if (raceNode == null)
            {
                // TODO: ask the business or find the feed docs and determine if we might have multiple races. If so, this
                // would need to find the right way of identifying the correct race
                throw new RaceDataInvalidException("Expected 1 race in the source document");
            }

            var race = new HorseRace()
            {
                RaceName = xdoc.XPathSelectElement("/meeting/track").Attribute("TranslatedName").Value,
                _horses = ParseHorses(raceNode)
            };

            return race;
        }

        private List<Horse> ParseHorses(XElement raceNode)
        {
            var horses = new List<Horse>();
            foreach (var horse in raceNode.XPathSelectElements("horses/horse"))
            {
                var horseNumber = horse.Element("number").Value;
                var priceNode = raceNode.XPathSelectElement($"prices/price/horses/horse[@number='{horseNumber}']");
                if (priceNode == null)
                {
                    throw new RaceDataInvalidException("no price found for horse number " + horseNumber);
                }
                horses.Add(new Horse()
                {
                    HorseName = horse.Attribute("name").Value,
                    Price = decimal.Parse(priceNode.Attribute("Price").Value)
                });
            }
            return horses;
        }
    }
}
