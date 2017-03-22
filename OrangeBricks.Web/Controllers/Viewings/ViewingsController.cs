﻿using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Viewings.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings
{
    [OrangeBricksAuthorize(Roles = "Seller")]
    public class ViewingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult OnProperty(int id)
        {
            var builder = new ViewingsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

    }
}