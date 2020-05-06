using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TheSocialNetwork.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public bool PublicPost { get; set; }
        public DateTime Published {get; set; }
        public List<Circle> Circles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}