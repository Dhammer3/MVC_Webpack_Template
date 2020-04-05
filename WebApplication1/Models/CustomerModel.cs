using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class CustomerModel
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("phone")]
        public string phone { get; set; }
    }
}