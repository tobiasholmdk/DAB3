using System.Collections.Generic;
using MongoDB.Driver;
using TheSocialNetwork.Models;

namespace TheSocialNetwork.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TheSocialNetwork");

            _users = database.GetCollection<User>("Users");
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User Get(int id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _users.Find(user => user.Name == name).FirstOrDefault();
        }

        public Circle GetCircleByCircleName(User user, string name)
        {
            return user.Circles.Find(x => x.CircleName == name);
        }

        public List<Circle> GetCirclesByUser(User user)
        {
            var users = Get();
            var circleList = new List<Circle>();
            foreach (var u in users)
            {
                var hasUser = u.Circles.Find(x => x.MemberId.Contains(user.Id));
                if (hasUser != null)
                {
                    circleList.Add(hasUser);
                }
            }

            return circleList;
        }

        public void Create(User user)
        {
            _users.InsertOne(user);
        }

        public void Update(int id, User userIn)
        {
            _users.ReplaceOne(user => user.Id == id, userIn);
        }

        public void RemoveUser(User userIn)
        {
            _users.DeleteOne(user => user.Id == userIn.Id);
        }

        public void RemoveAll()
        {
            _users.DeleteMany(user => user.Id != null);
        }
    }
}