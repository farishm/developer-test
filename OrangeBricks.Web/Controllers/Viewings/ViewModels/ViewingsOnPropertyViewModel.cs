using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Controllers.Viewings.ViewModels
{
    public class ViewingsOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms{ get; set; }
        public string StreetName { get; set; }
        public bool HasViewings { get; set; }
        public IEnumerable<ViewingViewModel> Viewings { get; set; }
        public int PropertyId { get; set; }
    }

    public class ViewingViewModel
    {
        public int Id;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Viewing Date")]
        public DateTime ViewingDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Viewing Time")]
        public DateTime ViewingTime { get; set; }
    }
}
