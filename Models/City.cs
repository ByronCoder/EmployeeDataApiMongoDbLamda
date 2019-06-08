using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeesApiMongoDb.Models {
    public class City {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}
        [BsonElement("name")]
        public string Name { get; set; }
        
    }
}