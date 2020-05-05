using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class Circle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("Circle Name")]
        public string CircleName { get; set; }
        [BsonElement("Member ID")]
        public List<User> Members { get; set; }
    }
}