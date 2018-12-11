using Beteasy.RaceDataProviders;
using Beteasy.RaceDataProviders.Implementation;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class UkJsonRaceDataProviderTests
    {
        [Fact]
        public async Task ValidData_ParsedCorrectly()
        {
            var mockDataLoader = new MockDataLoader("Uk_Race_Valid.json");
            var unitUnderTest = new UkJsonRaceDataProvider(mockDataLoader);
            var result = await unitUnderTest.GetRaceDataAsync("mockRaceId");

            var horseList = result.Horses.ToList();
            Assert.Equal("13:45 @ Wolverhampton", result.RaceName);
            Assert.Equal(2, horseList.Count);

            Assert.Equal("Toolatetodelegate", horseList[0].HorseName);
            Assert.Equal(10.0M, horseList[0].Price);
            Assert.Equal("Fikhaar", horseList[1].HorseName);
            Assert.Equal(4.4M, horseList[1].Price);
        }

        [Fact]
        public async Task NoMarkets_ThrowsRaceDataInvalidException()
        {
            var mockDataLoader = new MockDataLoader("Uk_Race_NoMarkets.json");
            var unitUnderTest = new UkJsonRaceDataProvider(mockDataLoader);
            await Assert.ThrowsAsync<RaceDataInvalidException>(async () => await unitUnderTest.GetRaceDataAsync("mockRaceId"));
        }
    }
}
