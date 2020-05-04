using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSocialNetwork.Models;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Queries
{
    class FeedView
    {
        private readonly PostService _postService;
        private readonly UserService _userService;

        public void ShowFollowedUserPost(User user)
        {
            var posts = _postService.GetByFollowedUsers(user);
            foreach (var x in posts)
            {
                Console.WriteLine("User " + x.Author + " Posted " + x.Content + " Time Posted: " + x.Published);
            }
        }
        public void ShowPostsInCircle(User user, Circle circle)
        {
            var _circle = _userService.GetCircleByCircleName(user, circle.CircleName);
            foreach (var x in _circle.Members)
            {
                var post = _postService.Get().Where(y => y.Author == x);
                
                foreach (var z in post)
                {
                Console.WriteLine("User " + z.Author + " Posted " + z.Content + " Time Posted: " + z.Published);
                }
            }
        }

        public void UserFeed(User user)
        {
            //var _followedPosts = _postService.GetByFollowedUsers(user);
            var _ownposts = _postService.GetByAuthor(user);
            var _userCircles = _userService.GetCirclesByUser(user);

            Console.WriteLine("Your posts");
            foreach (var x in _ownposts)
            {
                Console.WriteLine( "Post " + x.Content + " Time Posted: " + x.Published);
            }

            Console.WriteLine("-----------------------------------------------------------");

            foreach (var x in _userCircles)
            {
                Console.WriteLine("Circle Name: " + x.CircleName);
                var circlepost = _postService.GetPostsFromCircle(x);
                foreach (var y in circlepost)
                {
                    Console.WriteLine("User " + y.Author + " Posted " + y.Content + " Time Posted: " + y.Published);
                }
            }
            
            Console.WriteLine("-----------------------------------------------------------");

            ShowFollowedUserPost(user);

        }
    }
}
