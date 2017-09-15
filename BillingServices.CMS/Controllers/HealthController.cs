using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingServices.CMS.Core.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BillingServices.CMS.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController:Controller
    {

        private IRespository repository;
        private ILogger logger;
        
         

        public HealthController(IRespository repository, ILogger<HealthController> logger)
        {
            this.repository = repository;
            this.logger = logger;
            logger.LogInformation("Health Check Initialized");
        }

        // GET: api/Health 
        [HttpGet]
        public IEnumerable<ResponsePair<string, string>> Get()
        {
            logger.LogInformation("Health Check Started");
            List <ResponsePair<string, string>> responseList = new List<ResponsePair<string, string>>();

            responseList.Add(GetCheckDatabaseStatus());
            //Add Depencies as they are added

            logger.LogInformation("Healtch Check Complete");
            return responseList;

        }

        private  ResponsePair<string, string> GetCheckDatabaseStatus()
        {
            string message = "N/A";
            
            logger.LogInformation("Health Check Started for Mongo");
            try
            { 
                if (repository.GetContext().isAvailable)
                {
                        message =  "OK";
                        logger.LogInformation("Health Check Mongo returned OK");

                }
            }
            catch(System.TimeoutException toe)
            {
                message = "Database TimeOut";
                logger.LogInformation("Health Check Mongo Database TimeOut", toe);
            }

            return new ResponsePair<string, string>
            {
                Dependency = "MongoDb",
                Value = message
            };

        
        }

       public struct ResponsePair<K,V>
        {
            public K Dependency { get; set; }
            public K Value { get; set; }
        }
    }


    
}