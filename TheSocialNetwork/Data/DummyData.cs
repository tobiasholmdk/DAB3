using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using TheSocialNetwork.Queries;
using TheSocialNetwork.Models;
using TheSocialNetwork.Queries;
using TheSocialNetwork.Services;

namespace TheSocialNetwork.Data
{
    class DummyData
    {
        private readonly UserService _userService;
        private readonly PostService _postService;
        private readonly Creations _creations;



        private List<Circle> _circles;
        private List<Comment> _comments;
        private List<Post> _posts;
        private List<User> _users;

        public DummyData()
        {
            _userService = new UserService();
            _postService = new PostService();
            Users();
            Circles();
        }

        public void Circles()
        {
            _circles = new List<Circle>
            {
                new Circle
                {
                    CircleName = "Vi elsker høns",
                    Members = new List<User>
                    {
                        _users[0],
                        _users[1],
                        _users[2],
                        _users[3]
                    }
                },
                new Circle
                {
                    CircleName = "Dabbedab",
                    Members = new List<User>
                    {
                        _users[0],
                        _users[1],
                        _users[2]
                    }
                },
                new Circle
                {
                    CircleName = "Pepsi Entusiater",
                    Members = new List<User>()
                }
            };
            // User 0
            var user = _userService.Get(_users[0]);
            user.Circles.Add(_circles[0]);
            user.Circles.Add(_circles[1]);
            // User 1
            user = _userService.Get(_users[1]);
            user.Circles.Add(_circles[0]);
            user.Circles.Add(_circles[1]);
            // User 2
            user = _userService.Get(_users[2]);
            user.Circles.Add(_circles[0]);
            user.Circles.Add(_circles[1]);
            // User 3
            user = _userService.Get(_users[3]);
            user.Circles.Add(_circles[0]);
        }
        public void Comments()
        {
            _comments = new List<Comment>
            {
                new Comment
                {
                    Content = "Nej",
                    Created = DateTime.Now,
                    Author = _users[2]
                },
                new Comment
                {
                    Content = "Der er ikke nogen PM funktionalitet på dette system?",
                    Created = DateTime.Now,
                    Author = _users[1]
                }
            };
            
            // Post 2
            var post = _postService.Get(_posts[2]);
            post.Comments.Add(_comments[0]);
            // Post 3
            post = _postService.Get(_posts[3]);
            post.Comments.Add(_comments[1]);

        }
        public void Posts()
        {
            _posts = new List<Post>
            {
                //Public posts: 
                new Post
                {
                    Author = _users[1],
                    Content = "Fuck hvor fedt at få 12 i Engelsk A niveau :D!!!!!!",
                    PublicPost = true,
                    Published = DateTime.Now

                },

                //Clicle posts:
                new Post
                {
                    Author = _users[3],
                    Content = "Hvordan steger man et kyliingebryst bedst?",
                    PublicPost = false,
                    Published = DateTime.Now,
                    Circles = new List<Circle> {_circles[0] },
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Content = "Ej det kan du ikke skrive her",
                            Author = _users[0],
                            Created = DateTime.Now
                        },
                        new Comment
                        {
                            Content = "7 min på hver side på stegepanden",
                            Author = _users[2],
                            Created = DateTime.Now
                        },
                        new Comment
                        {
                            Content = "Ikk spis kylling! #VeganLife!",
                            Author = _users[1],
                            Created = DateTime.Now
                        },
                    }
                },

                //Clicle posts:
                new Post
                {
                    Content = "Syntes i også at semester 4 er svært?",
                    Author = _users[0],
                    PublicPost = false,
                    Published = DateTime.Now,
                    Circles = new List<Circle>
                    {
                        _circles[1]
                    },
                    Comments = new List<Comment>
                    {
                        _comments[0]
                    }        
                    
                },
                new Post
                {
                    Content = "Jeg sælger min Cykel. PM mig, hvis nogen er intereseret",
                    Author = _users[2],
                    PublicPost = true,
                    Published = DateTime.Now,
                    Circles = _circles,
                    Comments = new List<Comment>
                    {
                        _comments[1]
                    }
                }
            };

            foreach (var x in _posts)
            {
                _postService.Create(x);
            }
        }

        public void Users()
        {
            _users = new List<User>
            {
                new User
                {
                    Name = "Morten",
                    Age = 25,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>(),
                    FollowedUsers = new List<User>()    

                },
                new User
                {
                    Name = "Tobias",
                    Age = 25,
                    Gender = "Other",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>
                    {
                        _users[3]
                    },
                    FollowedUsers = new List<User>
                    {
                        _users[0],
                        _users[2]
                    }
                },
                new User
                {
                    Name = "Frederik",
                    Age = 23,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>(),
 
                    FollowedUsers = new List<User>
                    {                                          
                        _users[0],
                        _users[1],
                        _users[3]                    
                    }
                },
                new User
                {
                    Name = "Klara",
                    Age = 30,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>
                    {
                        _users[0],
                        _users[1]
                    },
                    FollowedUsers = new List<User>
                    {
                        _users[2]
                    }


                },
            };
            foreach (var x in _users)
            {
                _userService.Create(x);
            }

        }
    }
}
