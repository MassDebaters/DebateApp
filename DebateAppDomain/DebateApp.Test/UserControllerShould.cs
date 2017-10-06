using DebateApp.Domain;
using DebateAppDomainAPI.Controllers;
using DebateAppDomainAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DebateAppDomain.Test
{
    public class UserControllerShould
    {
        private readonly ITestOutputHelper _output;
        private DBHelper dbh;
        private UserController UCUT;
        private UserModel umut;
        public UserControllerShould(ITestOutputHelper Output)
        {
            _output = Output;
            dbh = new DBHelper();
            UCUT = new UserController();

            umut = new UserModel()
            {
                Username = "SteveHarvey",
                Password = "IHateMyself6969"
            };
        }

        [Fact]
        public void CreateAUser()
        {
            var actual = UCUT.RegisterUser(umut);
            var check = UCUT.GetUser(actual.AccountId).Username;
            Assert.IsType<UserModel>(actual);
            Assert.Equal("SteveHarvey", check);
            
        }
    }
}
