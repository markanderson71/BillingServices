using System;
using System.Collections.Generic;
using System.Text;
using BillingServices.CMS.Core.Interfaces;
using Microsoft.Extensions.Options;

namespace BillingServices.CMS.Data
{
    public class DatabaseSettings 
    {
       public string ConnectionString { get; set; }
       public string Database { get ; set ; }
    }
}
