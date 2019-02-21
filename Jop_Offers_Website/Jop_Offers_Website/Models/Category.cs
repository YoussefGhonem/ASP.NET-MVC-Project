using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jop_Offers_Website.Models
{
    public class Category
    {
        public int Id { get; set; } //PK
        [Required]
        [DisplayName("CategoryName")]
        public string CategoryName { get; set; }
        [Required]
        [DisplayName("CategoryDescription")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Jop> Jop { get; set; }
    }
}