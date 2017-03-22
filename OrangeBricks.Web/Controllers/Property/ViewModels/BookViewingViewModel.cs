using System;
using System.ComponentModel.DataAnnotations;
namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class BookViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Viewing Date")]
        public DateTime ViewingDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Viewing Time")]
        public DateTime ViewingTime { get; set; }

        public int PropertyId { get; set; }
    }
}




