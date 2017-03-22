using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }

        public string BuyerUserId { get; set; }
       
        public DateTime ViewingDate { get; set; }
        
        public DateTime ViewingTime { get; set; }

        public virtual Property Property { get; set; }


    }
}