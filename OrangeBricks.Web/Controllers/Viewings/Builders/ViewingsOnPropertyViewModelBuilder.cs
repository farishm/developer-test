using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings.Builders
{
    public class ViewingsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ViewingsOnPropertyViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Viewings)
                .SingleOrDefault();

            var viewings = property.Viewings ?? new List<Viewing>();

            return new ViewingsOnPropertyViewModel
            {
                HasViewings = viewings.Any(),
                Viewings = viewings.Select(x => new ViewingViewModel
                {
                    Id = x.Id,
                    ViewingDate=x.ViewingDate,
                    ViewingTime=x.ViewingTime
                }),
                PropertyId = property.Id, 
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms
            };
        }
    }
}