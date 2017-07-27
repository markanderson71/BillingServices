using System;
using System.Collections.Generic;
using System.Text;
using BillingServices.CMS.Core.Interfaces;
using BillingServices.CMS.Core.Model;

namespace BillingServices.CMS.Core
{
    public class CustomerManager
    {
        private IRespository repository;
        public CustomerManager(IRespository repository)
        {
            this.repository = repository;
        }


        public IEnumerable<Customer> GetCustomers()
        {
            return repository.Get();
        }
        
        public Customer findByCustomerId(string id)
        {
            return repository.GetById(id);
        }
         
    }
}
