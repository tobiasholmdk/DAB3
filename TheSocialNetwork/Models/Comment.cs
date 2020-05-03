using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class Comment
    {
        [BsonElement("Comment Content")]
        public string Content { get; set; }
        [BsonElement("Time of Comment")]
        public DateTime Created {get; set; }
        [BsonElement("Comment Author")]
        public string Author {get; set; }
    }
}