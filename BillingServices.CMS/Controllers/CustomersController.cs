﻿using System;
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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillingServices.CustomerManagementService
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
       
        private CustomerManager customerManager;
        private IMapper mapper;
        
        public CustomersController(IRespository repository, IMapper mapper)
        {
           
           this.customerManager = new CustomerManager(repository);
            this.mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            List<Customer> X = customerManager.GetCustomers().ToList<Customer>();

            return customerManager.GetCustomers();
        }

        // GET api/customers/5
        [HttpGet("{id}", Name ="GetCustomer")]
        public Customer Get(string id)
        {
            
            return customerManager.findByCustomerId(id); ;            
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]CustomerPostViewModel model)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var customer = mapper.Map<Customer>(model);
                string newCustomerId = customerManager.Add(customer);

                return CreatedAtRoute("GetCustomer", new { id = newCustomerId }, newCustomerId);
            }
            catch(Exception ex)
            {
                //TODO: Add Exception Logging
                return StatusCode(500);
            }
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]CustomerPostViewModel model)
        {
            if (!ModelState.IsValid || String.IsNullOrEmpty(id) || model == null) 
            {
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
                return BadRequest();
            }

            return Accepted(id);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(id ==null)
            {
                return BadRequest();
            }

            try
            {
                customerManager.Delete(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return NotFound(id);
            }
            

            return NoContent();
        }
    }
}
