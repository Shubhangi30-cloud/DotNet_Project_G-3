using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETradingSystem.Models
{
    public class ProductMVC
    {
        public int product_id { get; set; }

        public string brand_name { get; set; }

        public int brand_id { get; set; }

        public int vendor_id { get; set; }

        public int brand_price { get; set; }

        public int availability { get; set; }
    }
}