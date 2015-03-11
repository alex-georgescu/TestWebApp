using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TestWebApp.Models;
using TestWebApp.Services;


namespace TestWebApp
{
    public partial class MainWebForm : System.Web.UI.Page
    {
        private List<PropertyListing> _PropertiesNearby;
        

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoadedProperties"] == null)
            {
                PropertyListingService pls = new PropertyListingService();
                _PropertiesNearby = await pls.GetPropertiesAsync();

                if (_PropertiesNearby != null)
                {
                    PropertiesListView.DataSource = _PropertiesNearby;
                    PropertiesListView.DataBind();

                    Session.Add("LoadedProperties", _PropertiesNearby);

                    PropertyListing selectedProperty = _PropertiesNearby.First();
                    LoadPropertyPreview(ref selectedProperty);
                }    
            }
            else
            {
                _PropertiesNearby = Session["LoadedProperties"] as List<PropertyListing>;
                
                PropertiesListView.DataSource = _PropertiesNearby;
                PropertiesListView.DataBind();
            }
        }


        protected void lvProperties_SelectedChanged(object sender, EventArgs e)
        {
            _PropertiesNearby = Session["LoadedProperties"] as List<PropertyListing>;
            if (_PropertiesNearby != null)
            {
                PropertyListing selectedProperty = _PropertiesNearby[PropertiesListView.SelectedIndex];
                LoadPropertyPreview(ref selectedProperty);
            }
        }

        private void LoadPropertyPreview(ref PropertyListing selectedProperty)
        {
            if (selectedProperty != null)
            {
                PropertyDetailsView.DataSource = new List<PropertyListing>() { selectedProperty };
                PropertyDetailsView.DataBind();
            }
        }

        protected void lvProperties_SelectedChanging(object sender, ListViewSelectEventArgs e)
        {
            
        }
    }
}