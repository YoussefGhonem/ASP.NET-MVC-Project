using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jop_Offers_Website.Models
{
    public class Contact
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Msg{ get; set; }
    }
}