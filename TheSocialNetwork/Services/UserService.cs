using System.Collections.Generic;
using MongoDB.Driver;
using TheSocialNetwork.Models;
using System.Linq;


namespace TheSocialNetwork.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
       // private readonly IMongoCollection<Circle> _circles;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TheSocialNetworkDatabase");
            
            _users = database.GetCollection<User>("Users");
           // _circles = database.GetCollection<User>("Users");
        }

        public List<User> Get()
        {
            return _users.Find(u => true).ToList();
        }

        public User Get(User user)
        {
            return _users.Find(u => u == user).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _users.Find(u => u.Name == name).FirstOrDefault();
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
                var hasUser = u.Circles.Find(x => x.Members.Contains(user));
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

        public void Update(string name, User user)
        {
            _users.ReplaceOne(u => u.Name == name, user);
        }

        public void RemoveUser(User user)
        {
            _users.DeleteOne(u => u.Name == user.Name);
        }

        public void RemoveAll()
        {
            _users.DeleteMany(u => u.Name != null);
        }

        public bool checkIfBlocked(User user_id, User user_guest)
        {
            bool IsBlocked = false;
            foreach(var x in user_id.BlockedUsers)
            {
                if(user_guest == x)
                {
                    IsBlocked = true;
                }                
            }
            return IsBlocked;

        }
    }
}