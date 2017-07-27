using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BillingServices.CMS.Core.Interfaces;
using System.Linq.Expressions;
using BillingServices.CMS.Core;
using BillingServices.CMS.Core.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingServices.CustomerManagementService
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
       
        private CustomerManager customerManager;

        
        public CustomersController(IRespository repository)
        {
           
           this.customerManager = new CustomerManager(repository);
            
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerManager.GetCustomers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(string id)
        {
            
            return customerManager.findByCustomerId(id); ;
                        
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
