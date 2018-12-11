using Beteasy.RaceDataProviders;
using Beteasy.RaceDataProviders.Implementation;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class AusXmlRaceDataProviderTests
    {
        [Fact]
        public async Task ValidData_ParsedCorrectly()
        {
            var mockDataLoader = new MockDataLoader("Aus_Race_valid.xml");
            var unitUnderTest = new AusXmlRaceDataProvider(mockDataLoader);

            var result = await unitUnderTest.GetRaceDataAsync("mockRaceId");

            var horseList = result.Horses.ToList();
            Assert.Equal("Caulfield", result.RaceName);
            Assert.Equal(2, horseList.Count);

            Assert.Equal("Advancing", horseList[0].HorseName);
            Assert.Equal(4.2M, horseList[0].Price);
            Assert.Equal("Coronel", horseList[1].HorseName);
            Assert.Equal(12M, horseList[1].Price);
        }

        [Fact]
        public async Task NoRaces_ThrowsRaceDataInvalidException()
        {
            var mockDataLoader = new MockDataLoader("Aus_Race_NoRaces.xml");
            var unitUnderTest = new AusXmlRaceDataProvider(mockDataLoader);
            await Assert.ThrowsAsync<RaceDataInvalidException>(async () => await unitUnderTest.GetRaceDataAsync("mockRaceId"));
        }

        [Fact]
        public async Task EmptyFile_ThrowsRaceDataInvalidException()
        {
            var mockDataLoader = new MockDataLoader("Aus_Race_EmptyFile.xml");
            var unitUnderTest = new AusXmlRaceDataProvider(mockDataLoader);
            await Assert.ThrowsAsync<RaceDataInvalidException>(async () => await unitUnderTest.GetRaceDataAsync("mockRaceId"));
        }
    }
}
