using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jop_Offers_Website.Models
{
    public class ListUserOfJops
    {
        public string JopTitle { get; set; }
        public IEnumerable<ApplyForJop> Items { get; set; }
    }
}