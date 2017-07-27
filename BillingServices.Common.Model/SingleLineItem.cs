using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    //this class is designed to be a test bed for types of individual LineItems
    public class SingleLineItem:ILineItem
    {

        public  int Order { get; set; }
    }
}
