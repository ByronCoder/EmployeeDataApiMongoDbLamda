using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace EmployeesApiMongoDb.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("department")]
        public string Department { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }
    }
}
