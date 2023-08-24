using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TEMPLATE.Models
{
    public class Rules
    {
        public int product_min_count { get; set; }
        public int product_max_count { get; set; }
        public bool free_shipping { get; set; }
        public int discount_percentage { get; set; }
        public string message { get; set; }
        public string applied_msg { get; set; }
    }

}