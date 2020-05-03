using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("User Name")]
        public string Name { get; set; }

        [BsonElement("User Gender")]
        public string Gender { get; set; }
        [BsonElement("User Circles")]
        public List<Circle> Circles { get; set; }
        [BsonElement("User Age")]
        public int Age { get; set; }
        [BsonElement("Followed Users")]
        public List<User> FollowedUsers { get; set; }
        [BsonElement("Users blocked users")]
        public List<string> BlockedUsers { get; set; }
    }
}