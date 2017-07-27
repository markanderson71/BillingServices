using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BillingServices.CustomerManagementService.Model;
using BillingServices.CMS.Interface;
using System.Linq.Expressions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingServices.CustomerManagementService
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IRespository repository;

        public CustomerController(IRespository repository)
        {
            this.repository = repository;

        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Common.Model.Data.ICustomer Get(string id)
        {
            Customer C = repository.Single<Customer>(d => d.CustomerName == "Mark Anderson");
       
            return C;

            //return new Customer() { CustomerId = new Guid(), CustomerName = "Test Name"};
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
