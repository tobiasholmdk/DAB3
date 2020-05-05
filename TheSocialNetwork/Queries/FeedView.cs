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

        public FeedView()
        {
            _postService = new PostService();
            _userService = new UserService();
        }

        public void ShowFollowedUserPost(User user)
        {
            var posts = _postService.GetByFollowedUsers(user);
            foreach (var x in posts)
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
        }

        public void ShowOwnPost(User user)
        {

            var _ownposts = _postService.GetByAuthor(user);

            Console.WriteLine("Your posts");
            foreach (var x in _ownposts)
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

                //Console.WriteLine("Post " + x.Content + " Time Posted: " + x.Published);
            }          
            
        }

        public void ShowPostsInCircle(User user, Circle circle)
        {
            var _circle = _userService.GetCircleByCircleName(user, circle.CircleName);
            foreach (var x in _circle.Members)
            {
                var post = _postService.Get().Where(y => y.Author.Name == x.Name);
                
                foreach (var z in post)
                {
                    Console.WriteLine("User " + z.Author + " Posted " + z.Content + " Time Posted: " + z.Published);
                }
            }
        }

        public void ShowPostsInAllCircles(User user)
        {
            List<Circle> userCircles = _userService.GetCirclesByUser(user);
            List<Post> postInCircles; 


            foreach (var c in userCircles)
            {                
                Console.WriteLine("Posts in: " + c.CircleName);

                postInCircles = _postService.GetPostsFromCircle(c);

                foreach (var x in postInCircles)
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

                //ShowPostsInCircle(user, c);
            }



            //List<Post> userCirclesPosts = _postService.GetPostsFromAllCircles(userCircles);

            //foreach(var x in userCirclesPosts)
            //{
            //    Console.WriteLine("");
            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");

            //    Console.WriteLine(x.Author.Name + " writes:");
            //    Console.WriteLine(x.Content + " - Date: " + x.Published);

            //    Console.WriteLine("");

            //    Console.WriteLine("--Comments--");
            //    List<Comment> comments = _postService.GetCommentsByPost(x);
            //    foreach (var c in comments)
            //    {
            //        Console.WriteLine("  * " + c.Author.Name + " has commented:");
            //        Console.WriteLine("      - " + c.Content + " - Date: " + c.Created);
            //    }

            //    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            //    Console.WriteLine("");

            //}

            


            //_postService
            //foreach (var x in _userCircles)
            //{
            //    Console.WriteLine("Circle Name: " + x.CircleName);
            //    var circlepost = _postService.GetPostsFromCircle(x);
            //    foreach (var y in circlepost)
            //    {
            //        Console.WriteLine("User " + y.Author.Name + " Posted " + y.Content + " Time Posted: " + y.Published);
            //    }
            //}

        }


        public void UserFeed(User user)
        {      
            var _userCircles = _userService.GetCirclesByUser(user);

            Console.WriteLine("***Your posts***");
            ShowOwnPost(user);

            Console.WriteLine("");

            Console.WriteLine("***Followed users posts***");
            ShowFollowedUserPost(user);

            

            Console.WriteLine("***Your circles posts***");
            ShowPostsInAllCircles(user);

            Console.WriteLine("");


            //Console.WriteLine("-----------------------------------------------------------");

            //foreach (var x in _userCircles)
            //{
            //    Console.WriteLine("Circle Name: " + x.CircleName);
            //    var circlepost = _postService.GetPostsFromCircle(x);
            //    foreach (var y in circlepost)
            //    {
            //        Console.WriteLine("User " + y.Author.Name + " Posted " + y.Content + " Time Posted: " + y.Published);
            //    }
            //}

            //Console.WriteLine("-----------------------------------------------------------");


        }

        public void showAllUsers()
        {
            List<User> allUsers = _userService.Get();

            foreach(var u in allUsers)
            {
                Console.WriteLine("UserName: " + u.Name);
            }

        }
    }
}
