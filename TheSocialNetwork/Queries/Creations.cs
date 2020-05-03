using System;
using System.Collections.Generic;
using TheSocialNetwork.Models;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Queries
{    
    internal class Creations
    {
        private readonly PostService _postService;
        private readonly UserService _userService;
        public Creations()
        {
            _postService = new PostService();
            _userService = new UserService();
        }

        public void CreateUser(string name, int age, string gender)
        {
            var newUser = new User
            {
                Name = name,
                Age = age,
                Gender = gender,
                Circles = new List<Circle>(),
                BlockedUsers = new List<string>()
            };

            _userService.Create(newUser);
        }

        public void CreatePost(User author, string postType, string content, bool publicPost, List<Circle> circles)
        {
            var newPost = new Post
            {
                Author = author.Name,
                Content = content,
                Published = DateTime.Now,
                PublicPost = publicPost,
                Circles = circles,
                Comments = new List<Comment>()
            };

            _postService.Create(newPost);
        }

        public void CreateComment(User author, Post post, string comment)
        {
            var newComment = new Comment
            {
                Author = author,
                Content = comment,
                Created = DateTime.Now
            };

            post.Comments.Add(newComment);
            _postService.Create(post);
        }

        public void CreateCircle(User users, string name)
        {
            var newCircle = new Circle
            {
                CircleName = name,
                MemberNames = new List<string>()
            };
            
            users.Circles.Add(newCircle);
            _userService.Update(users.Name, users);
        }

    }
}