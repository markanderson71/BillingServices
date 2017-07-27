using System;
using System.Linq.Expressions;
using BillingServices.CMS.Core.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using BillingServices.CMS.Core.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Collections.Generic;

namespace BillingServices.CMS.Data
{
    public class MongoRepository : IRespository
    {

     
        private DBContext dbContext;

        public MongoRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
            SetSerializationForObjectId();
        }

        private static void SetSerializationForObjectId()
        {
            BsonClassMap.RegisterClassMap<Customer>(cm => { cm.AutoMap(); cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId)); });
        }


        public IEnumerable<Customer> Get()
        {
            var collection = dbContext.Current().GetCollection<Customer>("Customers");
            return collection.AsQueryable().Where(_ => true);
        }

        public Customer GetById(string id)
        {
           var collection = dbContext.Current().GetCollection<Customer>("Customers");
           return collection.AsQueryable().Where(cust => cust.Id == id).SingleOrDefault();
           
        }


    }
}
