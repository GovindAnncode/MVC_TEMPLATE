using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TEMPLATE
{
    public class MenuItems
    {
        public int id { get; set; }
        public string platform_collection_id { get; set; } // Allow null values
        public string platform_product_id { get; set; }   // Allow null values
        public string image_url { get; set; }
        public string title { get; set; }
        public string page_url { get; set; }
    }
}