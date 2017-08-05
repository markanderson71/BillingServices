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
            //Customer Class Needs Serilaizatino because of ObjectId string
            //but can only be registered once if not exception occurs
            if (!BsonClassMap.IsClassMapRegistered(typeof(Customer)))
            {
                SetSerializationForObjectId();
            }
            
        }

        private static void SetSerializationForObjectId()
        {
            BsonClassMap.RegisterClassMap<Customer>(cm => { cm.AutoMap(); cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId)); });
           // BsonClassMap.RegisterClassMap<Customer>(cm => { cm.AutoMap(); cm.IdMemberMap(new StringSerializer(BsonType.ObjectId)); });
        }

        private IMongoCollection<Customer> GetCustomerCollection()
        {
            return dbContext.Current().GetCollection<Customer>("Customers");
        }

       
        public IEnumerable<Customer> Get()
        {                        
            
            return GetCustomerCollection().AsQueryable().Where(_ => true);
        }

        public Customer GetById(string id)
        {
            
           return GetCustomerCollection().AsQueryable().Where(cust => cust.Id == id).SingleOrDefault();
           
        }

        public string Add(Customer customer)
        {
            
            customer.Id = ObjectId.GenerateNewId().ToString();
            
            GetCustomerCollection().InsertOne(customer);
            return customer.Id;
        }


        public void Delete(string customerId)
        {

            var collection = dbContext.Current().GetCollection<Customer>("Customers");

            try { 
               
                var result = collection.DeleteOne(Builders<Customer>.Filter.Eq("Id", ObjectId.Parse(customerId)));

                if (result.DeletedCount <= 0)
                {
                    throw new ArgumentException("CustomerId was not found in databse for value:" + customerId);
                }

            }
            catch(FormatException)
            {
                throw new ArgumentOutOfRangeException("CustomerId is not an ObjectId value: " + customerId);
            }
            

            
        }

        public void Update(Customer customer)
        {
            try
            {
                GetCustomerCollection().ReplaceOne<Customer>(p => p.Id == customer.Id, customer, new UpdateOptions { IsUpsert = true });
            }
            catch (FormatException)
            {
                throw new ArgumentOutOfRangeException("CustomerId is not an ObjectId value: " + customer.Id);
            }
        }


        public IDBContext GetContext()
        {
            return dbContext;
        }
    }
}
