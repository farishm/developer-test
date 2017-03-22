using System;
namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookViewingCommand
    {
        public int PropertyId { get; set; }
        public DateTime ViewingDate { get; set; }
        public DateTime ViewingTime { get; set; }
        public string BuyerUserId { get; set; }
    }
}