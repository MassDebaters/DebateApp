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
                Username = "Biggo",
                Password = "Titties"
            };
        }

        [Fact]
        public void CreateAUser()
        {
            var actual = UCUT.RegisterUser(umut);
            UserModel umut2 = new UserModel()
            {
                Username = "Greg",
                Password = "foo"
            };
            
            var check = UCUT.GetUser(actual.AccountId).Username;
            Assert.IsType<UserModel>(actual);
            Assert.Equal("Biggo", check);
            dbh.DBDeleteUser(dbh.DBGetUser("Biggo").AccountId);

            var actual2 = UCUT.RegisterUser(umut2);
            Assert.Null(actual2);
        }
        [Fact]
        public void JoinATeam()
        {
            UCUT.JoinTeam("Biggo", 0);
        }
    }
}
