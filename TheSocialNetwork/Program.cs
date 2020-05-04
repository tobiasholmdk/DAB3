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

        private static PostService _postService;
        private static List<Post> _posts;

        static void Main(string[] args)
        {
            DummyData myDummyData = new DummyData();
            myDummyData.SeedData();

            _userService = new UserService();
            _users = _userService.Get();

            _postService = new PostService();
            _posts = _postService.Get();

            Console.WriteLine("***Testing users and circles***");
            Console.WriteLine("");
            foreach (var u in _users)
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

                Console.WriteLine("  * Circles: ");
                foreach(var cl in u.Circles)
                {                    
                    Console.WriteLine("     - " + cl.CircleName);
                }

                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------------------------------------");   
            }

            Console.WriteLine("***Testing posts***");
            Console.WriteLine("");
            foreach(var p in _posts)
            {
                Console.WriteLine(p.Author.Name + " writes:");
                Console.WriteLine(p.Content + " - Date: " + p.Published);

                Console.WriteLine("");

                Console.WriteLine("--Comments--");
                List<Comment> comments = _postService.GetCommentsByPost(p);
                foreach(var c in comments)
                {
                    Console.WriteLine("  * " + c.Author.Name + " has commented:");
                    Console.WriteLine("      - " + c.Content + " - Date: " + c.Created);
                }
            }








        }
    }
}