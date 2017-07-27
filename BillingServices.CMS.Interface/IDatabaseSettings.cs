using System;
using System.Collections.Generic;
using System.Text;
//using BillingServices.CMS.Core.Interfaces;
//using Microsoft.Extensions.Options;

namespace BillingServices.CMS.Data
{
    public interface IDatabaseSettings
    {
         string ConnectionString { get; set; }
         string Database { get; set; }
    }
}

