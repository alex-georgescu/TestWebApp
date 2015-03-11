using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TestWebApp.HttpHelper;
using TestWebApp.Models;
using TestWebApp.Services;
using TestWebApp.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestWebApp.Tests
{
    [TestClass]
    public class HttpLayerTests
    {

        [TestMethod]
        public void HttpGetMethodTest()
        {
            Task.Run(async () =>
            {
                string requestUri = string.Format("{0}?area={1}&api_key={2}", "http://api.zoopla.co.uk/api/v1/property_listings.json", "London", Constants.API_KEY);
                string resultAsString = await HttpGetHelper.GetAsync(requestUri);

                Assert.IsNotNull(resultAsString);

                PropertyListingServerResponse listingResponse = JsonConvert.DeserializeObject<PropertyListingServerResponse>(resultAsString);

                Assert.IsNotNull(listingResponse);

                List<PropertyListing> properties = listingResponse.Listing;

                Assert.IsNotNull(properties);
            });
        }
       
    }
}
