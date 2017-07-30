using BillingServices.CMS.Core.Model;
using System;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;

namespace BillingServices.CMS.Core.Interfaces
{
    public interface IRespository 
    {

        IEnumerable<Customer> Get();

        Customer GetById(string id);

        string Add(Customer customer);

        void Delete(string customerId);

        void Update(Customer customer);
    }
}
