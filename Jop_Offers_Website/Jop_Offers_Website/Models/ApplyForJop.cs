using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jop_Offers_Website.Models;

namespace Jop_Offers_Website.Models
{
    public class ApplyForJop
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public DateTime ApplyDate { get; set; }
        
        public int JopId { get; set; }
        public string UserId { get; set; }

        public virtual Jop jop { get; set; }
        public virtual ApplicationUser user { get; set; }


    }
}