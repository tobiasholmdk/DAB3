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
        
        public Post Get(Post post) 
        {
            return _posts.Find(p => p == post).FirstOrDefault();
        }
        public List<Post> GetByAuthor(User user)
        {
            return _posts.Find(p => p.Author == user).ToList();
        }

        public List<Post> GetPostByUser(User user)
        {
            return _posts.Find(p => p.Author == user).ToList();
        }

        public List<Post> GetPostsFromCircle(Circle circle)
        {
            return _posts.Find(p => p.Circles.Contains(circle)).ToList();
        }

        public List<Post> GetPostsFromAllCircles(List<Circle> circles)
        {
            //var circles = _userService.GetCirclesByUser(user);
            List<Post> posts = new List<Post>();
            foreach (var x in circles)
            {
                posts.AddRange(GetPostsFromCircle(x));
            }
            return posts;
        }

        public List<Post> GetByFollowedUsers(User user)
        {
            List<Post> posts = new List<Post>();
            foreach (var x in user.FollowedUsers)
            {
                posts = _posts.Find(p => p.Author == x).ToList();
            }
            return posts;
        }
        
        public void Create(Post post)
        {
            _posts.InsertOne(post);
        }

        public void Remove(Post post)
        {
            _posts.DeleteOne(p => p.Author == post.Author);
        }

        public void RemoveAll()
        {
            _posts.DeleteMany(p => p.Author != null);
        }
    }
}
