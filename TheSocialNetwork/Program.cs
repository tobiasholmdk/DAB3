using System;
using System.Collections.Generic;
using TheSocialNetwork.Data;
using TheSocialNetwork.Models;
using TheSocialNetwork.Queries;
using TheSocialNetwork.Services;

namespace TheSocialNetwork
{
    class Program
    {
        private static UserService _userService;
        private static List<User> _users;
        static void Main(string[] args)
        {
            _userService = new UserService();
            _users = _userService.Get();

            DummyData myDummyData = new DummyData();
            myDummyData.SeedData();

            foreach(var u in _users)
            {
                Console.WriteLine("Name: " + u.Name + ", Gender: " + u.Gender + ", Age: " + u.Age);
                Console.WriteLine("  * Follows:");

                foreach(var fu in u.FollowedUsers)
                {                    
                    Console.WriteLine("     - " + fu.Name);
                }                
                Console.WriteLine("  * Blocks:");
                foreach (var bu in u.BlockedUsers)
                {
                    Console.WriteLine("     - " + bu.Name);
                }


                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------------------------------------");   
            }





        }
    }
}