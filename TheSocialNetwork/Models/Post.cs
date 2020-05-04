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
        public ObjectId Id { get; set; }

        [BsonElement("Post Author")]
        public User Author { get; set; }
        [BsonElement("Post Content")]
        public string Content { get; set; }
        [BsonElement("Public Post")]
        public bool PublicPost { get; set; }
        [BsonElement("Time Published")]
        public DateTime Published {get; set; }
        [BsonElement("Posted to circles")]
        public List<Circle> Circles { get; set; }
        [BsonElement("Comments to post")]
        public List<Comment> Comments { get; set; }
    }
}