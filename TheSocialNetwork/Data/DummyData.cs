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
        private List<User> _users;
        private List<Post> _posts;

        private List<Circle> _circles;
        private List<Comment> _comments;


        public DummyData()
        {
            _userService = new UserService();
            _postService = new PostService();
        }

        public void SeedData()
        {
            _postService.RemoveAll();
            _userService.RemoveAll();

            Users();
            UsersFollowerAndBlocked();
            Circles();
            Posts();

            //Comments();

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
                    BlockedUsers = new List<User>(),
                    FollowedUsers = new List<User>()
                },
                new User
                {
                    Name = "Frederik",
                    Age = 23,
                    Gender = "Male",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>(),
                    FollowedUsers = new List<User>()
                },
                new User
                {
                    Name = "Klara",
                    Age = 30,
                    Gender = "Female",
                    Circles = new List<Circle>(),
                    BlockedUsers = new List<User>(),
                    FollowedUsers = new List<User>()
                }
            };
            foreach (var x in _users)
            {
                _userService.Create(x);
            }
        }

        public void UsersFollowerAndBlocked()
        {
            //Morten:
            var tempMorten = _userService.GetUserByName("Morten");
            tempMorten.FollowedUsers = new List<User>
            {
                _userService.GetUserByName("Tobias")
            };
            _userService.Update("Morten", tempMorten);

            //Tobias:
            var tempTobias = _userService.GetUserByName("Tobias");
            tempTobias.FollowedUsers = new List<User>
            {
                _users[0],
                _users[2]                
            };
            tempTobias.BlockedUsers = new List<User>
            {
                _users[3]
            };
            _userService.Update("Tobias", tempTobias);

            //Frederik:
            var tempFrederik = _userService.GetUserByName("Frederik");
            tempFrederik.FollowedUsers = new List<User>
            {
                _users[0],
                _users[1],
                _users[3]
            };
            _userService.Update("Frederik", tempFrederik);

            //Klara
            var tempKlara = _userService.GetUserByName("Klara");
            tempKlara.FollowedUsers = new List<User>
            {
                _users[2]
            };
            tempKlara.BlockedUsers = new List<User>
            {
                _users[0],
                _users[1]
            };
            _userService.Update("Klara", tempKlara);
        }

        public void Circles()
        {
            _circles = new List<Circle>
            {
                new Circle
                {
                    CircleName = "Vi elsker høns",
                    Members = new List<User>()
                },
                new Circle
                {
                    CircleName = "Os på 4. semester",
                    Members = new List<User>()
                },
                new Circle
                {
                    CircleName = "Meme Entusiater",
                    Members = new List<User>()
                }

            };
            
            var tempUser = _userService.GetUserByName("Morten");
            tempUser.Circles.Add(_circles[0]);
            tempUser.Circles.Add(_circles[1]);
            _userService.Update("Morten", tempUser);

            tempUser =_userService.GetUserByName("Tobias");
            tempUser.Circles.Add(_circles[0]);
            tempUser.Circles.Add(_circles[1]);
            _userService.Update("Tobias", tempUser);

            tempUser = _userService.GetUserByName("Frederik");
            tempUser.Circles.Add(_circles[0]);
            tempUser.Circles.Add(_circles[1]);
            tempUser.Circles.Add(_circles[2]);
            _userService.Update("Frederik", tempUser);

            tempUser = _userService.GetUserByName("Klara");
            tempUser.Circles.Add(_circles[0]);
            _userService.Update("Klara", tempUser);
        }

        public void Posts()
        {
            _posts = new List<Post>
            {
                new Post
                {
                    Author = _users[1],
                    Content = "Fuck hvor fedt at få 7 i Matematik C :D!!!!!!",
                    PublicPost = true,
                    Published = DateTime.Now,
                    Comments = new List<Comment>
                    {
                        new Comment()
                        {
                            Author = _userService.GetUserByName("Frederik"), //Alternativt _users[2]
                            Content = "Ej hvor flot!!! Det har du virkeligt også arbejdet hårdt for <333",
                            Created = DateTime.Now
                        },
                        new Comment()
                        {
                            Author = _userService.GetUserByName("Morten"), //Alternativt _users[0]
                            Content = "Tillykke!",
                            Created = DateTime.Now
                        },
                    }
                },
                new Post
                {
                    Author = _users[3],
                    Content = "Hvordan steger man et kyliingebryst bedst?",
                    PublicPost = false,
                    Published = DateTime.Now,
                    Circles = new List<Circle> {_circles[0]},
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Content = "Ej det kan du ikke skrive her?!",
                            Author = _users[0],
                            Created = DateTime.Now
                        },
                        new Comment
                        {
                            Content = "7 min ved mellem varme på hver side.",
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
                new Post
                {
                    Content = "Syntes i også at semester 4 er svært?",
                    Author = _users[0],
                    PublicPost = false,
                    Published = DateTime.Now,
                    Circles = new List<Circle> { _circles[1] },
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Content = "Nej.",
                            Created = DateTime.Now,
                            Author = _userService.GetUserByName("Frederik")
                        }
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
                        new Comment
                        {
                            Content = "Der er ikke nogen PM funktionalitet på dette system?",
                            Created = DateTime.Now,
                            Author = _users[0]
                        }
                    }
                }
            };
            foreach (var x in _posts)
            {
                _postService.Create(x);
            }   
            

        }



        public void Comments()
        {
            _comments = new List<Comment>
            {
                new Comment
                {
                    Content = "Måske lidt",
                    Created = DateTime.Now,
                    Author = _users[1]                    
                }              
            };
            var tempPost = _posts[2];
            tempPost.Comments.Add(_comments[0]);
            _postService.Update(tempPost, _posts[0]);
        }       
    }
}
