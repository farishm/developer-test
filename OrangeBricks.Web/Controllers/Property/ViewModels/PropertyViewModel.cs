using System.Collections.Generic;
namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class PropertyViewModel
    {
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
        public int Id { get; set; }
        public bool IsListedForSale { get; set; }

        public ICollection<OrangeBricks.Web.Models.Offer> PropertyOffers { get; set; }
        public ICollection<OrangeBricks.Web.Models.Viewing> PropertyViewings { get; set; }
    }
}