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

            Console.Write("Please enter your name to log in: ");
            string loggedInUserName = Console.ReadLine();
            var loggedInUser = _userService.GetUserByName(loggedInUserName);

            if(loggedInUser == null)
            {
                Console.WriteLine("No existing users goes by that name.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("About - Page");
                Console.WriteLine("");

                Console.WriteLine("Name: " + loggedInUser.Name + ", Gender: " + loggedInUser.Gender + ", Age: " + loggedInUser.Age);
                Console.WriteLine("  * Follows:");

                foreach (var fu in loggedInUser.FollowedUsers)
                {
                    Console.WriteLine("     - " + fu.Name);
                }
                Console.WriteLine("  * Blocks:");
                foreach (var bu in loggedInUser.BlockedUsers)
                {
                    Console.WriteLine("     - " + bu.Name);
                }

                Console.WriteLine("");

                Console.WriteLine("  * Circles: ");
                foreach (var cl in loggedInUser.Circles)
                {
                    Console.WriteLine("     - " + cl.CircleName);
                }

                Console.WriteLine("");


                Console.WriteLine("Menu - Page");
                Console.WriteLine("");

                Console.WriteLine("   - Show user-feed (1)");
                Console.WriteLine("   - Show user-wall (2)");
                Console.WriteLine("   - Make post      (3)");
                Console.WriteLine("");

                Console.Write("Please 1, 2 or 3 to make use of TheSocialNetworks functionallities: ");
                string menuNavigation = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");



                FeedView myFeedView = new FeedView();
                WallView myWallView = new WallView();

                switch (menuNavigation)
                {
                    case "1":
                        Console.WriteLine("user-feed - Page");
                        myFeedView.UserFeed(loggedInUser);
                        break;
                    case "2":
                        Console.Write("Show wall for: ");

                        string showUserName = Console.ReadLine();
                        var showUser = _userService.GetUserByName(showUserName);

                        if (showUser == null)
                        {
                            Console.WriteLine("No existing users goes by that name.");
                        }
                        else
                        {
                            myWallView.wall(showUser, loggedInUser);
                        }                     

                        break;
                    case "3":
                        Console.WriteLine("Make post - Page");
                        break;
                    default:
                        Console.Write("Please 1, 2 or 3 to make use of TheSocialNetworks functionallities: ");
                        break;
                }
            }

            





            //Console.WriteLine("***Testing posts***");
            //Console.WriteLine("");
            //foreach (var p in _posts)
            //{
            //    Console.WriteLine("");
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //    Console.WriteLine(p.Author.Name + " writes:");
            //    Console.WriteLine(p.Content + " - Date: " + p.Published);

            //    Console.WriteLine("");

            //    Console.WriteLine("--Comments--");
            //    List<Comment> comments = _postService.GetCommentsByPost(p);
            //    foreach (var c in comments)
            //    {
            //        Console.WriteLine("  * " + c.Author.Name + " has commented:");
            //        Console.WriteLine("      - " + c.Content + " - Date: " + c.Created);
            //    }
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //    Console.WriteLine("");
            //}





            //Orginal testkode: 


            //Console.WriteLine("***Testing users and circles***");
            //Console.WriteLine("");
            //foreach (var u in _users)
            //{
            //    Console.WriteLine("Name: " + u.Name + ", Gender: " + u.Gender + ", Age: " + u.Age);
            //    Console.WriteLine("  * Follows:");

            //    foreach (var fu in u.FollowedUsers)
            //    {
            //        Console.WriteLine("     - " + fu.Name);
            //    }
            //    Console.WriteLine("  * Blocks:");
            //    foreach (var bu in u.BlockedUsers)
            //    {
            //        Console.WriteLine("     - " + bu.Name);
            //    }

            //    Console.WriteLine("");

            //    Console.WriteLine("  * Circles: ");
            //    foreach (var cl in u.Circles)
            //    {
            //        Console.WriteLine("     - " + cl.CircleName);
            //    }

            //    Console.WriteLine("");
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //}

            //Console.WriteLine("***Testing posts***");
            //Console.WriteLine("");
            //foreach (var p in _posts)
            //{
            //    Console.WriteLine("");
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //    Console.WriteLine(p.Author.Name + " writes:");
            //    Console.WriteLine(p.Content + " - Date: " + p.Published);

            //    Console.WriteLine("");

            //    Console.WriteLine("--Comments--");
            //    List<Comment> comments = _postService.GetCommentsByPost(p);
            //    foreach (var c in comments)
            //    {
            //        Console.WriteLine("  * " + c.Author.Name + " has commented:");
            //        Console.WriteLine("      - " + c.Content + " - Date: " + c.Created);
            //    }
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //    Console.WriteLine("");
            //}








        }
        public void showUserWall()
        {
            
        }
    }
}