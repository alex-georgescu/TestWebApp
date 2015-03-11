using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp.Models;

namespace TestWebApp.Services
{
    public class PropertyListingServerResponse
    {
        public string Country { get; set; }
        public long Result_Count { get; set; }
        public double Longitude { get; set; }
        public string Area_Name { get; set; }
        public List<PropertyListing> Listing { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public double Latitude { get; set; }
	    public string County { get; set; }
	    public string Postcode { get; set; } 

    }
}