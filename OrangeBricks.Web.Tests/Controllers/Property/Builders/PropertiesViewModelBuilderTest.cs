using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Tests.Controllers.Property.Builders
{
    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    [TestFixture]
    public class PropertiesViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnPropertiesWithMatchingStreetNamesWhenSearchTermIsProvided()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);

            var properties = new List<Models.Property>{
                new Models.Property{ StreetName = "Smith Street", Description = "", IsListedForSale = true },
                new Models.Property{ StreetName = "Jones Street", Description = "", IsListedForSale = true}
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Smith Street"
            };

            // Act
            var viewModel = builder.Build(query);

            // Assert
            Assert.That(viewModel.Properties.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuildShouldReturnPropertiesWithMatchingDescriptionsWhenSearchTermIsProvided()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);

            var properties = new List<Models.Property>{
                new Models.Property{ StreetName = "", Description = "Great location", IsListedForSale = true },
                new Models.Property{ StreetName = "", Description = "Town house", IsListedForSale = true }
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Town"
            };

            // Act
            var viewModel = builder.Build(query);

            // Assert
            Assert.That(viewModel.Properties.Count, Is.EqualTo(1));
            Assert.That(viewModel.Properties.All(p => p.Description.Contains("Town")));
        }

         [Test]
        public void BuildShouldReturnAcceptedOfferforProperties()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);

            var properties = new List<OrangeBricks.Web.Models.Property>{
                new OrangeBricks.Web.Models.Property{
                    StreetName = "Smith Street",
                    Description = "",
                    IsListedForSale = true,

                     Offers = new List<Offer>
                     {
                        new Offer
                            {
                                 BuyerUserId = "45667",
                                 Status = OfferStatus.Accepted
                            }
                     }
                }
            };

            var mockSet = Substitute.For<IDbSet<OrangeBricks.Web.Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Smith Street"
            };

            // Act
            var viewModel = builder.Build(query);

            var prpsWithAcceptedOffers = viewModel.Properties.Select(p => p.PropertyOffers);          

            // Assert
            Assert.That(prpsWithAcceptedOffers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuildShouldReturnVirewingsforProperties()
        {
            // Arrange
            var builder = new PropertiesViewModelBuilder(_context);

            var properties = new List<OrangeBricks.Web.Models.Property>{
                new OrangeBricks.Web.Models.Property{
                    StreetName = "Smith Street",
                    Description = "",
                    IsListedForSale = true,

                     Viewings = new List<Viewing>
                     {
                        new Viewing
                            {
                                 BuyerUserId = "45667",
                                 ViewingDate=DateTime.Now,
                                 ViewingTime=DateTime.Now
                            },
                             new Viewing
                            {
                                 BuyerUserId = "78889",
                                 ViewingDate=DateTime.Now,
                                 ViewingTime=DateTime.Now
                            }
                     }
                }
            };

            var mockSet = Substitute.For<IDbSet<OrangeBricks.Web.Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            var query = new PropertiesQuery
            {
                Search = "Smith Street"
            };

            // Act
            var viewModel = builder.Build(query);

            var viewings = viewModel.Properties[0].PropertyViewings;            

            // Assert
            Assert.That(viewings.Count, Is.EqualTo(2));
        }
    }
}
