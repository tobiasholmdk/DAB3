using System;
using System.Collections.Generic;
using System.Text;
using TheSocialNetwork.Models;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Queries
{
    class WallView
    {
        private readonly PostService _postService;
        private readonly UserService _userService;

        public WallView()
        {
            _postService = new PostService();
            _userService = new UserService();
        }

        public void wall(User user_id, User guest_id)
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                 " + user_id.Name + "'s Wall");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            
            bool isBlocked = _userService.checkIfBlocked(user_id, guest_id);
            
            if (isBlocked == false)
            {
                //Tjekker public posts:

                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                 " + user_id.Name + "'s Public Posts");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                
                var followedUserWall = _postService.GetByAuthor(user_id);

                foreach(var x in followedUserWall)
                {
                    if(x.PublicPost == true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                        Console.WriteLine(x.Author.Name + " writes:");
                        Console.WriteLine(x.Content + " - Date: " + x.Published);

                        Console.WriteLine("");

                        Console.WriteLine("--Comments--");
                        List<Comment> comments = _postService.GetCommentsByPost(x);
                        foreach (var c in comments)
                        {
                            Console.WriteLine("  * " + c.Author.Name + " has commented:");
                            Console.WriteLine("      - " + c.Content + " - Date: " + c.Created);
                        }

                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                        Console.WriteLine("This post is private");

                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                    }                   
                }

                //Tjekker circles begge er medlem af: 
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                 " + user_id.Name + "'s posts in circles you are a member of");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");

                var userCircleList = _userService.GetCirclesByUser(user_id);
                var guestCircleList = _userService.GetCirclesByUser(guest_id);

                var commonCircles = new List<Circle>();

                foreach(var x in userCircleList)
                {
                    foreach(var z in guestCircleList)
                    {
                        if(x.CircleName == z.CircleName)
                        {                            
                            commonCircles.Add(x);
                        }
                    }
                }

                var commonCirclePost = _postService.GetPostsFromAllCircles(commonCircles);

                foreach (var x in commonCirclePost)
                {
                    if (x.Author.Name == user_id.Name)
                    {
                        if (x.PublicPost == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                            Console.WriteLine(x.Author.Name + " writes:");
                            Console.WriteLine(x.Content + " - Date: " + x.Published);

                            Console.WriteLine("");

                            Console.WriteLine("--Comments--");
                            List<Comment> comments = _postService.GetCommentsByPost(x);

                            foreach (var co in comments)
                            {
                                Console.WriteLine("  * " + co.Author.Name + " has commented:");
                                Console.WriteLine("      - " + co.Content + " - Date: " + co.Created);
                            }

                            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("");
                        }                        
                    }                    
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"!!!You have been blocked by {user_id.Name}!!!");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
            }      

            

        }



    }
}
