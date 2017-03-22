using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class BookViewingModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookViewingModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookViewingViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new BookViewingViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                ViewingDate=DateTime.Now,
                ViewingTime = DateTime.Now
            };
        }
    }
}