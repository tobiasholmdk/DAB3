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
        static void Main(string[] args)
        {  
            DummyData myDummyData = new DummyData();
            myDummyData.SeedData();

            //FeedView feedView = new FeedView();
            //feedView.showAllUsers();

            


        }
    }
}