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

        public List<Post> GetPostByUser(User user)
        {
            return _posts.Find(p => p.Author == user.Name).ToList();
        }

        public List<Post> GetPostsFromCircle(Circle circle)
        {
            return _posts.Find(p => p.Circles.Contains(circle)).ToList();
        }

        public void Create(Post post)
        {
            _posts.InsertOne(post);
        }

        public void Remove(Post post)
        {
            _posts.DeleteOne(p => p.Id == post.Id);
        }

        public void RemoveAll()
        {
            _posts.DeleteMany(p => p.Id != null);
        }

    }
}
