using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class AcceptedOfferViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasAcceptedOffer { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}