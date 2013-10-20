using System.Linq;
using Xunit;

namespace Specs.For.YelpApi
{
    public class YelpApiTests
    {
        [Fact]
        public void We_should_be_able_to_connect_to_the_Yelp_Api()
        {
            // Todo: Remove Dependency on YelpSharp from return value.
            var apiResponse = YelpApiWrapper.YelpApi.GetAllDiveBarsInDenver();
            apiResponse.Wait();
            Assert.True(apiResponse.IsCompleted);
            Assert.NotNull(apiResponse.Result);
            Assert.NotEmpty(apiResponse.Result.businesses);
        }

        [Fact]
        public void We_should_be_able_to_get_a_business_by_name()
        {
            // Todo: Remove Dependency on YelpSharp from return value.
            var apiResponse = YelpApiWrapper.YelpApi.GetBarsBySearchTerm("Shag Lounge");
            apiResponse.Wait();
            var bars = apiResponse.Result;
            Assert.True(bars.businesses.First().name.ToLower().Contains("shag lounge"));
        }
    }
}
