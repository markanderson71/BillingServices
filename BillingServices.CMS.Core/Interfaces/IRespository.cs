using BillingServices.CMS.Core.Model;
using System;
using System.Linq.Expressions;


namespace BillingServices.CMS.Core.Interfaces
{
    public interface IRespository 
    {


        Customer GetById(string id);
        
        


    }
}
