using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    public class BillingQuarter : Quarter
    {
       LineItems quarterItems = new LineItems();

        public BillingQuarter(DateTime dateinQuarter) : base(dateinQuarter)
        {

        }

       
    }
}
