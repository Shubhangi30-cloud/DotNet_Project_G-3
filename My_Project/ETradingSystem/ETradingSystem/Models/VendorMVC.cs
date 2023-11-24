using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETradingSystem.Models
{
    public class VendorMVC
    {
        [DisplayName("Vendor ID")]
        public int vendor_id { get; set; }

        [DisplayName("Vendor Name")]
        public string vendor_name { get; set; }
        [DisplayName("Verification")]
        public int vendor_verification_card_id { get; set;  }
        [DisplayName("Phone no")]
        public int phone_no { get; set;  }

        public string password { get; set;  }
    }
}