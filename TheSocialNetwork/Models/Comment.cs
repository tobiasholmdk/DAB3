using System;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class Comment
    {
        public string Content { get; set; }
        public DateTime Created {get; set; }
        public User Author {get; set; }
    }
}