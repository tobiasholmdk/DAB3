using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TheSocialNetwork.Models;
namespace TheSocialNetwork.Services
{
    class PostService
    {
        private readonly IMongoCollection<Post> _posts;

        public PostService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TheSocialNetworkDatabase");

            _posts = database.GetCollection<Post>("Posts");
        }

        public List<Post> Get() =>
            _posts.Find(p => true).ToList();

        public Post GetById(int id)
        {
            return _posts.Find(p => p.Id == id).FirstOrDefault();
        }

        public Post GetbyUser(User user)
        {
            return _posts.Find(p => p.Author == user.Id).ToList();
        }


    }
}
