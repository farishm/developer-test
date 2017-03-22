using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class AcceptedOfferViewModelViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public AcceptedOfferViewModelViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public AcceptedOfferViewModel Build(int id, string buyerId)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Offers)
                .SingleOrDefault();           

            var offer = property.Offers.FirstOrDefault(o => o.Status == OfferStatus.Accepted && o.BuyerUserId == buyerId);
          
            bool hasAccptedOffer = (offer == null) ? false : true;

            int amount=0;
            DateTime createdAt=DateTime.Now;

            if (hasAccptedOffer)
            {
                amount = offer.Amount;
                createdAt = offer.CreatedAt;
            }

            return new AcceptedOfferViewModel
            {                                
                PropertyId = property.Id, 
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms,
                HasAcceptedOffer = hasAccptedOffer,
                Amount= amount,
                CreatedAt=createdAt
            };
        }
    }
}
