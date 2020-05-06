using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public List<Circle> Circles { get; set; }

        public int Age { get; set; }

        public List<User> FollowedUsers { get; set; }

        public List<User> BlockedUsers { get; set; }
    }
}