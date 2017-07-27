using BillingServices.Common.Model.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingServices.CustomerManagementService.Model
{


    public class Customer : ICustomer
    {

       [BsonId]
        public int  id { get; set ; }
        public string CustomerName { get; set; }


    }
}
