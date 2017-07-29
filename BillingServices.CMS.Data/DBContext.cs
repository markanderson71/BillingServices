using System;
using System.Collections.Generic;
using System.Text;
using BillingServices.CMS.Core.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;

namespace BillingServices.CMS.Data
{
    public class DBContext:IDBContext
    {

        private MongoClient client;
        private IMongoDatabase database = null;

        public DBContext(DatabaseSettings databaseSettings)
        {
            this.client = new MongoClient(databaseSettings.ConnectionString);
            this.database = client.GetDatabase(databaseSettings.Database);
            
        }

        public IMongoDatabase Current()
        {
            return database;
        }

        public bool isOpen { get; set; }

       
    }
}
