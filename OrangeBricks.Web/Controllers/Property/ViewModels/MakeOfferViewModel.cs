using System.ComponentModel.DataAnnotations;
namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MakeOfferViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        [DataType(DataType.Currency)]
        public int Offer { get; set; }
        public int PropertyId { get; set; }
    }
}