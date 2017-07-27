using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model.Data
{
    public class Customer:ICustomer
    {

        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        //public CustomerAddress Addresses { get; set; }



    }
}
