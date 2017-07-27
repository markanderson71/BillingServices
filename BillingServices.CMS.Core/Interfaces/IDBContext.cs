using System;
using System.Collections.Generic;
using System.Text;

namespace BillingServices.CMS.Core.Interfaces
{
    public interface IDBContext
    {

        bool isOpen { get; set; }
    }
}
