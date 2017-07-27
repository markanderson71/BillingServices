using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }

        public string City { get; set; }

        public string State_Province { get; set; }

        public string Zip_PostalCode { get; set; }

        public string Country { get; set; }


    }
}
