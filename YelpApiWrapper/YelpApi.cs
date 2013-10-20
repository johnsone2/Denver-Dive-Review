using System.Threading.Tasks;
using YelpSharp;
using YelpSharp.Data;

namespace YelpApiWrapper
{
    public static class YelpApi
    {
        public static readonly string _denverLocationCode = "denver, co";

        private static Options Options { get; set; }
        private static Yelp Yelp { get; set; }

        static YelpApi()
        {
            // Todo: Move to App.Config.
            Options = new Options
            {
                ConsumerKey = "u9vn-EsSLZ2EtEARoJSplA",
                ConsumerSecret = "5ZhUHLAuMm7CP_H9K_pLwMSEJP8",
                AccessToken = "9zUn7cxC57n8vogDu9wO0IVXFs-0SFXj",
                AccessTokenSecret = "SFnjTF_JA2lrMqcQNSghgL1U3oY"
            };
            Yelp = new Yelp(Options);
        }

        public static async Task<SearchResults> GetBarsBySearchTerm(string searchTerm)
        {
            return await Yelp.Search(searchTerm, _denverLocationCode);
        }

        public static async Task<SearchResults> GetAllDiveBarsInDenver()
        {
            return await GetBarsBySearchTerm("dive bars");
        }
    }
}
