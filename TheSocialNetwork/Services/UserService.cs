using System.Collections.Generic;
using MongoDB.Driver;
using TheSocialNetwork.Models;
using System.Linq;


namespace TheSocialNetwork.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
       

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TheSocialNetworkDatabase");
            
            _users = database.GetCollection<User>("Users");
          
        }

        public List<User> Get()
        {
            return _users.Find(u => true).ToList();
        }

        public User GetUserByName(string name)
        {
            return _users.Find(u => u.Name == name).FirstOrDefault();
        }
        

        public List<Circle> GetCirclesByUser(User user)
        {
           
            var circleList = new List<Circle>();
            foreach (var c in user.Circles)
            {
                circleList.Add(c);
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
        public void RemoveAll()
        {
            _users.DeleteMany(u => u.Name != null);
        }

        public bool checkIfBlocked(User user_id, User user_guest)
        {
            bool IsBlocked = false;
            foreach(var x in user_id.BlockedUsers)
            {
                if(user_guest.Name == x.Name)
                {
                    IsBlocked = true;
                }                
            }
            return IsBlocked;

        }
    }
}