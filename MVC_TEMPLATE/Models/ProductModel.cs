using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVC_TEMPLATE.Models
{
    public class ProductModel
    {
        public long ProductId;
        public string Title;
        public string Description;
        public List<string> Images;
        public string CreatedAt;
    }
}