using DebateApp.Domain;
using DebateAppDomainAPI.Controllers;
using DebateAppDomainAPI.Models;
using Newtonsoft.Json;
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
            dbh.DBDeleteUser(dbh.DBGetUser("Biggo").AccountId);
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
            UCUT.RegisterUser(umut);
            var simulatedJoinTeam = new FormDataModels.JoinDebateModel()
            {
                username = "Biggo",
                DebateID = 1,
                Opener = "NO! NOOOOOOO"
            };
            UCUT.JoinTeam(simulatedJoinTeam);
            var actual = dbh.DBGetDebate(1).d.Teams[1];
            Assert.NotEmpty(actual.Members);
            Assert.Equal("Biggo", actual.Members[0].Username);
            Assert.Equal("NO! NOOOOOOO", actual.Opener.CommentText);
            _output.WriteLine(JsonConvert.SerializeObject(actual));
        }
    }
}
