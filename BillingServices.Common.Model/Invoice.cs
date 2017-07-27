using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.Common.Model
{
    public class Invoice
    {
        //Definition contains the nessassary information to dispatch payment to the issuer.
        //Differs from bill as it has a list of items.
        //Invoice object is the articfacte.

        public int internalInvoiceNumber { get; set; }
        public int InvoiceNumber { get; set; }

        //public <ILineItems> InvoicedItems { get; set; }

        //public BilledAmount {get; set;}
                          
        //public Credits  {get; set;}



    }   
}       
        