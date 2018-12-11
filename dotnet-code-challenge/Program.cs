using Beteasy.RaceDataProviders;
using Beteasy.RaceDataProviders.Implementation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_code_challenge
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // In a real application, we would register the IHorseRaceDataProviderFactory with an IoC container
            // and use DI to inject it. However in this app we manually new it up 
            var factory = new HorseRaceDataProviderFactory();
            var caulfield = await GetRace(factory, "Caulfield_Race1");
            var wolverhampton = await GetRace(factory, "Wolferhampton_Race1");

            WriteRaceToConsoleInPriceOrder(caulfield);
            WriteRaceToConsoleInPriceOrder(wolverhampton);

            Console.ReadLine();
        }

        static void WriteRaceToConsoleInPriceOrder(HorseRace race)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Race: " + race.RaceName);
            foreach (var horse in race.Horses.OrderBy(h => h.Price))
            {
                Console.WriteLine($"Horse: {horse.HorseName}, Price: {horse.Price}");
            }
            Console.WriteLine("**********************");
        }

        static async Task<HorseRace> GetRace(IHorseRaceDataProviderFactory factory, string raceId)
        {
            return await factory.GetHorseRaceDataProvider(raceId).GetRaceDataAsync(raceId);
        }
    }
}
