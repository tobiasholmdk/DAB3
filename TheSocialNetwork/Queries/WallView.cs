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

        public void wall(User user_id, User guest_id)
        {
            bool isBlocked = _userService.checkIfBlocked(user_id, guest_id);

            if (isBlocked == false)
            {
                //Tjekker public posts:
                Console.WriteLine("Public Posts:");
                Console.WriteLine("--------------------------------------------------------------------");
                var followedUserWall = _postService.GetByAuthor(user_id);

                foreach(var x in followedUserWall)
                {
                    Console.WriteLine("User " + x.Author + " Posted " + x.Content + " Time Posted: " + x.Published);
                }
                Console.WriteLine("--------------------------------------------------------------------");

                //Tjekker circles begge er medlem af: 
                Console.WriteLine("Public Posts:");
                Console.WriteLine("--------------------------------------------------------------------");
                var userCircleList = _userService.GetCirclesByUser(user_id);
                var guestCircleList = _userService.GetCirclesByUser(guest_id);

                var commonCircles = new List<Circle>();

                foreach(var x in userCircleList)
                {
                    foreach(var z in guestCircleList)
                    {
                        if(x == z)
                        {
                            commonCircles.Add(x);
                        }
                    }
                }
                var commonCirclePost = _postService.GetPostsFromAllCircles(commonCircles);

                foreach(var x in commonCirclePost)
                {
                    Console.WriteLine("User " + x.Author + " Posted " + x.Content + " Time Posted: " + x.Published);
                }

                Console.WriteLine("--------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"You have been blocked from {user_id}");
            }
            

            

        }



    }
}
