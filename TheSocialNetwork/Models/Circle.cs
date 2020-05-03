using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace TheSocialNetwork.Models
{
    public class Circle
    {
        [BsonRequired]
        [BsonElement("Circle Name")]
        public string CircleName { get; set; }
        [BsonElement("Member ID")]
        public List<string> MemberNames { get; set; }
        
        /*[BsonElement("Post ID")]
        public List<int> PostId { get; set; }
        */
        
    }
}