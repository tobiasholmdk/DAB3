using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSocialNetwork.Models;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Queries
{
    class Views
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
            foreach (var x in _circle.MemberNames)
            {
                var post = _postService.Get().Where(y => y.Author == x);
                
                foreach (var z in post)
                {
                Console.WriteLine("User " + z.Author + " Posted " + z.Content + " Time Posted: " + z.Published);
                }
            }
        }

        public void UserFeedPost(User user)
        {
            
        }
    }
}
