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

        //public bool isAvailable { get { return ContactDatabase(); } set => throw new NotImplementedException(); }

        public bool isAvailable { get { return ContactDatabase(); } private set { } }
        public IMongoDatabase Current()
        {
            return database;
        }



        private bool  ContactDatabase()
        {
            //using database stats to verify database connection 
            var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "dbstats", 1 }, { "scale", 1 } });
            
            var result = this.database.RunCommand<BsonDocument>(command);
            return true;
        }

       
    }
}
