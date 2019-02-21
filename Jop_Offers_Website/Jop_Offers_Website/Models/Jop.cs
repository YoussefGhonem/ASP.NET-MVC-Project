using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Jop_Offers_Website.Models
{
    public class Jop
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("jop Title")]
        public string jopTitle{ get; set; }
        [Required]
        [DisplayName("jop Content")]
        public string jopContent{ get; set; }
        [Required]
        [DisplayName("jop Image")]
        public string jopImg { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; } //FK
        public virtual Category Category { get; set; }
       
    }
}