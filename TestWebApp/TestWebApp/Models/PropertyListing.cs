using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class PropertyListing
    {
        public int Num_Floors { get; set; }
        public string Listing_Status { get; set; }
        public int Num_Bedrooms { get; set; }
        public double Latitude { get; set; }
        public string Agent_Address { get; set; }
        public string Property_Type { get; set; }
        public double Longitude { get; set; }
        public Uri Thumbnail_Url { get; set; }
        public string Description { get; set; }
        public string Post_Town { get; set; }
        public Uri Details_Url { get; set; }
        public string Short_Description { get; set; }
        public string Outcode { get; set; }
        public string County { get; set; }
        public long Price { get; set; }
        public long Listing_Id { get; set; }
        public string Image_Caption { get; set; }
        public string Status { get; set; }
        public string Agent_Name { get; set; }
        public uint Num_recepts { get; set; }
        public string Country { get; set; }
        public string Displayable_Address { get; set; }
        public string First_Published_Date { get; set; }
        public string Price_Modifier { get; set; }
        public string Street_Name { get; set; }
        public uint Num_Bathrooms { get; set; }
        public Uri Agent_Logo { get; set; }
        public string Agent_Phone { get; set; }
        public Uri Image_Url { get; set; }
        public string Last_Published_Date { get; set; }
    }
}