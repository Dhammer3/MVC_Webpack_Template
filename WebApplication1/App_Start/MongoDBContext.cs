using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace WebApplication1.App_Start
{
    
    public class MongoDBContext
    {
        MongoClientBase client;
        public IMongoDatabase database;
        private string DB_ConnectionString;
        public MongoDBContext()
        {

            DB_ConnectionString = System.IO.File.ReadAllText(@"C:\Users\daren\source\repos\WebApplication1\WebApplication1\db_connection.txt");
            client = new MongoClient(DB_ConnectionString);
            database = client.GetDatabase("webApp1");

        }
    }
}
