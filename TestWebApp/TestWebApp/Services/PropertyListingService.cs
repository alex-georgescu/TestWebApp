using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestWebApp.HttpHelper;
using TestWebApp.Models;
using TestWebApp.Utils;


namespace TestWebApp.Services
{
    public class PropertyListingService
    {
        private readonly string baseUri = "http://api.zoopla.co.uk/api/v1/property_listings.json";

        public async Task<List<PropertyListing>>  GetPropertiesAsync()
        {
            string requestUri = string.Format("{0}?area={1}&api_key={2}", baseUri, "London", Constants.API_KEY);
            string resultAsString = await HttpGetHelper.GetAsync(requestUri);
            
            List<PropertyListing> properties = null;
            if (!string.IsNullOrEmpty(resultAsString))
            {
                try
                {
                    PropertyListingServerResponse listingResponse = JsonConvert.DeserializeObject<PropertyListingServerResponse>(resultAsString);
                    properties = listingResponse.Listing;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return properties;
        }
    }
}