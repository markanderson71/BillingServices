using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BillingServices.CMS.Core.Interfaces;
using System.Linq.Expressions;
using BillingServices.CMS.Core;
using BillingServices.CMS.Core.Model;
using BillingServices.CMS.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingServices.CustomerManagementService
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
       
        private CustomerManager customerManager;
        private IMapper mapper;
        private readonly ILogger logger;

        public CustomersController(IRespository repository, IMapper mapper, ILogger<CustomersController> logger)
        {
               
           this.customerManager = new CustomerManager(repository);
           this.mapper = mapper;
           this.logger = logger;
        }

        // GET: api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            logger.LogInformation("Get Customer Request");
            List<Customer> X = customerManager.GetCustomers().ToList<Customer>();
            logger.LogInformation("Get Customer Request Completed");
            return customerManager.GetCustomers();
            
        }

        // GET api/customers/5
        [HttpGet("{id}", Name ="GetCustomer")]
        public Customer Get(string id)
        {
            logger.LogInformation("Get Customer Request with id value of: {0}", id);
            var customer = customerManager.findByCustomerId(id);
            logger.LogInformation("Get Customer Request with id value of: {0} Complete", id);
            return customer;
            
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]CustomerPostViewModel model)
        {
            logger.LogInformation("Add Customer Request");
            if (!ModelState.IsValid)
            {
                logger.LogInformation("Add Customer Request Returned Bad Request");
                return BadRequest();
            }

            try
            {
                var customer = mapper.Map<Customer>(model);
                string newCustomerId = customerManager.Add(customer);
                logger.LogInformation("Add Customer Request Complete");
                return CreatedAtRoute("GetCustomer", new { id = newCustomerId }, newCustomerId);
            }
            catch(Exception ex)
            {
                logger.LogError("Add Custtomer Unexpected Exception", ex);
                return StatusCode(500);
            }
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]CustomerPostViewModel model)
        {
            logger.LogInformation("Updating Customer for id value: {0}", id);
            if (!ModelState.IsValid || String.IsNullOrEmpty(id) || model == null) 
            {
                logger.LogInformation("Add Customer Request Returned Bad Request");
                return BadRequest();
            }

            var customer = mapper.Map<Customer>(model);
            customer.Id = id;           
            try
            {
                customerManager.Update(customer);
            }
            catch (ArgumentOutOfRangeException)
            {
                logger.LogError("Updated Customer value {0} is invalid");
                return BadRequest();
            }
            logger.LogInformation("Updating Customer for id value: {0} complete", id);
            return Accepted(id);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            logger.LogInformation("Deleting Customer for id value: {0} complete", id);
            if (id ==null)
            {
                logger.LogError("Updated Customer value {0} is invalid");
                return BadRequest();
            }

            try
            {
                customerManager.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                logger.LogError("Updated Customer value {0} is in valid");
                return BadRequest();
            }
            catch (ArgumentException)
            {
                logger.LogInformation("Deleting Customer for id value: {0} was not found", id);
                return NotFound(id);
            }

            logger.LogInformation("Deleting Customer for id value: {0} complete", id);
            return NoContent();
        }
    }
}
